
using Application.Dto;
using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Gateway
{
    internal class ViewAllDepartmentGateway : IViewAllDepartmentRepository
    {
        private readonly AppDbContext appDbContext;

        public ViewAllDepartmentGateway(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<List<DepartmentListDto>> ViewAllAsync()
        {
            return await appDbContext.Departments
                .Select(d => new DepartmentListDto
                {
                    DepartmentId = d.DepartmentId,
                    Name = d.Name,
                    Location = d.Location
                }).ToListAsync();
        }
    }
}
