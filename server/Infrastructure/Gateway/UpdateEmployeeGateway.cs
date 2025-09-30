
using Application.Dto;
using Application.Interfaces;
using Application.Response;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Gateway
{
    internal class UpdateEmployeeGateway : IUpdateEmployeeRepository
    {
        private readonly AppDbContext appDbContext;

        public UpdateEmployeeGateway(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Employee?> GetByIdWithInfo(UpdateEmployeeDto updateEmployeeDto)
        {
            return await appDbContext.Employees
                .Include(e => e.PersonalInfo)
                .FirstOrDefaultAsync(e => e.EmployeeId == updateEmployeeDto.EmployeeId);
        }

        public async Task<bool> DepartmentExistsAsync(int departmentId)
        {
            return await appDbContext.Departments.AnyAsync(d => d.DepartmentId == departmentId);
        }

        public async Task<bool> EmailExistsAsync(int employeeId, string email)
        {
            return await appDbContext.EmployeePersonalInfos
                .AnyAsync(e => e.Email == email && e.EmployeeId != employeeId);
        }

        public async Task<bool> PhoneNumberExistsAsync(int employeeId, string phoneNumber)
        {
            return await appDbContext.EmployeePersonalInfos
                .AnyAsync(e => e.PhoneNumber == phoneNumber && e.EmployeeId != employeeId);
        }

        public async Task<UpdateEmployeeResponse> UpdateAsync(UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = await GetByIdWithInfo(updateEmployeeDto);

            if (employee == null)
            {
                return new UpdateEmployeeResponse(false, "Employee not found.");
            }

            employee.JobTitle = updateEmployeeDto.JobTitle;
            employee.Salary = updateEmployeeDto.Salary;
            employee.DepartmentId = updateEmployeeDto.DepartmentId;
            employee.IsActive = updateEmployeeDto.IsActive;

            if (employee.PersonalInfo != null && updateEmployeeDto.PersonalInfo != null)
            {
                employee.PersonalInfo.FirstName = updateEmployeeDto.PersonalInfo.FirstName;
                employee.PersonalInfo.LastName = updateEmployeeDto.PersonalInfo.LastName;
                employee.PersonalInfo.Gender = updateEmployeeDto.PersonalInfo.Gender;
                employee.PersonalInfo.Address = updateEmployeeDto.PersonalInfo.Address;
                employee.PersonalInfo.PhoneNumber = updateEmployeeDto.PersonalInfo.PhoneNumber;
                employee.PersonalInfo.Email = updateEmployeeDto.PersonalInfo.Email;
            }

            await appDbContext.SaveChangesAsync();

            return new UpdateEmployeeResponse(true, "Employee details successfully updated.", updateEmployeeDto);
        }

    }
}
