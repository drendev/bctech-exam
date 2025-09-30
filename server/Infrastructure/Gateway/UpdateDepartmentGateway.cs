
using Application.Dto;
using Application.Interfaces;
using Application.Response;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Gateway
{
    internal class UpdateDepartmentGateway : IUpdateDepartmentRepository
    {
        private readonly AppDbContext appDbContext;

        public UpdateDepartmentGateway(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<bool> DepartmentExistAsync(int departmentId, string departmentName)
        {
            return await appDbContext.Departments
                .AnyAsync(d => d.Name == departmentName && d.DepartmentId != departmentId);
        }

        public async Task<Department?> GetByIdWithInfo(UpdateDepartmentDto updateDepartmentDto)
        {
            return await appDbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == updateDepartmentDto.DepartmentId);
        }

        public async Task<UpdateDepartmentResponse> UpdateAsync(UpdateDepartmentDto updateDepartmentDto)
        {
            var department = await GetByIdWithInfo(updateDepartmentDto);

            if (department == null)
            {
                return new UpdateDepartmentResponse(false, "Department Not Found.");
            }

            department.Name = updateDepartmentDto.Name;
            department.Location = updateDepartmentDto.Location;

            await appDbContext.SaveChangesAsync();

            return new UpdateDepartmentResponse(true, "Department Successfully Updated", updateDepartmentDto);
        }
    }
}
