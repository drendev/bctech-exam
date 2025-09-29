
using Application.Dto;
using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Gateway
{
    internal class ViewAllEmployeesGateway : IViewAllEmployeesRepository
    {
        private readonly AppDbContext appDbContext;

        public ViewAllEmployeesGateway(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<List<EmployeesListDto>> GetAsync()
        {
            return await appDbContext.Employees
                .Include(e => e.PersonalInfo)
                .Include(e => e.Department)
                .Select(e => new EmployeesListDto
                {
                    EmployeeId = e.EmployeeId,
                    DepartmentName = e.Department.Name,
                    IsActive = e.IsActive,
                    FirstName = e.PersonalInfo.FirstName,
                    LastName = e.PersonalInfo.LastName,
                    JobTitle = e.JobTitle
                }).ToListAsync();
        }
    }
}
