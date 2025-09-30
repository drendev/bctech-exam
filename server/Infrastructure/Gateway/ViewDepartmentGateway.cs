
using Application.Dto;
using Application.Interfaces;
using Application.Response;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Gateway
{
    internal class ViewDepartmentGateway : IViewDepartmentRepository
    {
        private readonly AppDbContext appDbContext;

        public ViewDepartmentGateway(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ViewDepartmentDto?> ViewAsync(DepartmentIdDto departmentIdDto)
        {
            var department = await appDbContext.Departments
                .Include(d => d.Employees)
                .ThenInclude(e => e.PersonalInfo)
                .FirstOrDefaultAsync(d => d.DepartmentId == departmentIdDto.DepartmentId);

            var departmentDto = new ViewDepartmentDto
            {
                Name = department!.Name,
                Location = department!.Location,
                Employees = department!.Employees.Select(e => new EmployeesListDto
                {
                    EmployeeId = e.EmployeeId,
                    JobTitle = e.JobTitle,
                    FirstName = e.PersonalInfo.FirstName,
                    LastName = e.PersonalInfo.LastName,
                    IsActive = e.IsActive
                }).ToList()
            };

            return departmentDto;
        }
    }
}
