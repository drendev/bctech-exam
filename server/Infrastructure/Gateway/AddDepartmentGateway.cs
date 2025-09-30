
using Application.Dto;
using Application.Interfaces;
using Application.Response;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Gateway
{
    internal class AddDepartmentGateway : IAddDepartmentRepository
    {
        private readonly AppDbContext appDbContext;

        public AddDepartmentGateway(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<bool> DepartmentExistAsync(string departmentName)
        {
            return await appDbContext.Departments.AnyAsync(d => d.Name == departmentName);
        }

        public async Task<AddDepartmentResponse> AddAsync(DepartmentDto departmentDto)
        {
            var department = new Department
            {
                Name = departmentDto.Name,
                Location = departmentDto.Location
            };

            await appDbContext.Departments.AddAsync(department);
            await appDbContext.SaveChangesAsync();

            return new AddDepartmentResponse(true, "Added Department Successfully.");
        }
    }
}
