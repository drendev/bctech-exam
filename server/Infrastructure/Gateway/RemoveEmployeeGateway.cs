
using Application.Dto;
using Application.Interfaces;
using Application.Response;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Gateway
{
    internal class RemoveEmployeeGateway : IRemoveEmployeeRepository
    {
        private readonly AppDbContext appDbContext;
        private readonly IConfiguration configuration;

        public RemoveEmployeeGateway(AppDbContext appDbContext, IConfiguration configuration)
        {
            this.appDbContext = appDbContext;
            this.configuration = configuration;
        }

        public async Task<Employee?> GetByIdAsync(EmployeeIdDto employeeIdDto)
        {
            return await appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeIdDto.EmployeeId);
        }

        public async Task<RemoveEmployeeResponse> RemoveAsync(Employee employee)
        {
            appDbContext.Employees.Remove(employee);
            await appDbContext.SaveChangesAsync();

            return new RemoveEmployeeResponse(true, "Employee removed successfully.");
        }
    }
}
