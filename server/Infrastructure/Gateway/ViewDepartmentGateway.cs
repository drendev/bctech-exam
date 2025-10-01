
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
            return await appDbContext.Departments
                .Include(d => d.Employees)
                .ThenInclude(e => e.PersonalInfo)
                .Where(d => d.DepartmentId == departmentIdDto.DepartmentId)
                .Select(d => new ViewDepartmentDto
                {
                    Name = d.Name,
                    Location = d.Location,
                    Employees = d.Employees.Select(emp => new EmployeesListDto
                    {
                        EmployeeId = emp.EmployeeId,
                        FirstName = emp.PersonalInfo.FirstName,
                        LastName = emp.PersonalInfo.LastName,
                        DepartmentName = d.Name,
                        JobTitle = emp.JobTitle,
                        IsActive = emp.IsActive
                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }

    }
}
