
using Application.Dto;
using Application.Interfaces;
using Application.Response;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Gateway
{
    internal class AddEmployeeGateway : IAddEmployeeRepository
    {
        private readonly AppDbContext appDbContext;
        private readonly IConfiguration configuration;

        public AddEmployeeGateway(AppDbContext appDbContext, IConfiguration configuration)
        {
            this.appDbContext = appDbContext;
            this.configuration = configuration;
        }

        public async Task<bool> DepartmentExistsAsync(int departmentId)
        {
            return await appDbContext.Departments.AnyAsync(d => d.DepartmentId == departmentId);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await appDbContext.EmployeePersonalInfos.AnyAsync(e => e.Email == email);
        }

        public async Task<bool> PhoneNumberExistsAsync(string phoneNumber)
        {
            return await appDbContext.EmployeePersonalInfos.AnyAsync(p => p.PhoneNumber == phoneNumber);
        }

        public async Task<AddEmployeeResponse> AddAsync(EmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                JobTitle = employeeDto.JobTitle,
                Salary = employeeDto.Salary,
                DepartmentId = employeeDto.DepartmentId,
                PersonalInfo = new EmployeePersonalInfo
                {
                    FirstName = employeeDto.PersonalInfo!.FirstName,
                    LastName = employeeDto.PersonalInfo!.LastName,
                    Gender = employeeDto.PersonalInfo!.Gender,
                    Address = employeeDto.PersonalInfo!.Address,
                    PhoneNumber = employeeDto.PersonalInfo!.PhoneNumber,
                    Email = employeeDto.PersonalInfo!.Email
                }
            };

            await appDbContext.Employees.AddAsync(employee);
            await appDbContext.SaveChangesAsync();

            return new AddEmployeeResponse(true, "Employee added successfully.");
        }
    }
}
