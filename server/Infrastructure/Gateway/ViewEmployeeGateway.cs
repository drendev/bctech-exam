
using Application.Dto;
using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Gateway
{
    internal class ViewEmployeeGateway : IViewEmployeeRepository
    {
        private readonly AppDbContext appDbContext;

        public ViewEmployeeGateway(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<EmployeeDto?> GetAsync(EmployeeIdDto employeeIdDto)
        {
            return await appDbContext.Employees
                .Include(e => e.PersonalInfo)
                .Include(e => e.Department)
                .Where(e => e.EmployeeId == employeeIdDto.EmployeeId)
                .Select(e => new EmployeeDto
                {
                    JobTitle = e.JobTitle,
                    Salary = e.Salary,
                    DepartmentId = e.DepartmentId,
                    DepartmentName = e.Department.Name!,
                    IsActive = e.IsActive,
                    PersonalInfo = new PersonalInfoDto
                    {
                        FirstName = e.PersonalInfo.FirstName,
                        LastName = e.PersonalInfo.LastName,
                        Gender = e.PersonalInfo.Gender,
                        Address = e.PersonalInfo.Address,
                        PhoneNumber = e.PersonalInfo.PhoneNumber,
                        Email = e.PersonalInfo.Email
                    }
                }).FirstOrDefaultAsync();
        }
    }
}
