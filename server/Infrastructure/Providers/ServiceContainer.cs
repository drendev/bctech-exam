
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Application.Service;
using Infrastructure.Gateway;

namespace Infrastructure.Providers
{
    public static class ServiceContainer
    {
        public static IServiceCollection InfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default"),
            b => b.MigrationsAssembly(typeof(ServiceContainer).Assembly.FullName)),
            ServiceLifetime.Scoped);

            services.AddScoped<IAddEmployeeService, AddEmployeeService>();
            services.AddScoped<IAddEmployeeRepository, AddEmployeeGateway>();

            services.AddScoped<IRemoveEmployeeService, RemoveEmployeeService>();
            services.AddScoped<IRemoveEmployeeRepository, RemoveEmployeeGateway>();

            services.AddScoped<IUpdateEmployeeService, UpdateEmployeeService>();
            services.AddScoped<IUpdateEmployeeRepository, UpdateEmployeeGateway>();

            services.AddScoped<IViewEmployeeService, ViewEmployeeService>();
            services.AddScoped<IViewEmployeeRepository, ViewEmployeeGateway>();

            services.AddScoped<IViewAllEmployeesService, ViewAllEmployeesService>();
            services.AddScoped<IViewAllEmployeesRepository, ViewAllEmployeesGateway>();

            services.AddScoped<IAddDepartmentService, AddDepartmentService>();
            services.AddScoped<IAddDepartmentRepository, AddDepartmentGateway>();

            services.AddScoped<IUpdateDepartmentService, UpdateDepartmentService>();
            services.AddScoped<IUpdateDepartmentRepository, UpdateDepartmentGateway>();

            services.AddScoped<IViewDepartmentService, ViewDepartmentService>();
            services.AddScoped<IViewDepartmentRepository, ViewDepartmentGateway>();

            services.AddScoped<IViewAllDepartmentService, ViewAllDepartmentService>();
            services.AddScoped<IViewAllDepartmentRepository, ViewAllDepartmentGateway>();

            return services;
        }
    }
}
