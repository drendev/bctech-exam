
using Application.Dto;
using Application.Response;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IAddEmployeeService
    {
        Task<AddEmployeeResponse> AddAsync(EmployeeDto employeeDto);
    }

    public interface IAddEmployeeRepository
    {
        Task<AddEmployeeResponse> AddAsync(EmployeeDto employeeDto);
        Task<bool> DepartmentExistsAsync(int departmentId);
        Task<bool> EmailExistsAsync(string email);
        Task<bool> PhoneNumberExistsAsync(string phoneNumber);
    }

    public interface IRemoveEmployeeService
    {
        Task<RemoveEmployeeResponse> RemoveEmployeeAsync(EmployeeIdDto employeeIdDto);
    }

    public interface IRemoveEmployeeRepository
    {
        Task<Employee?> GetByIdAsync(EmployeeIdDto employeeIdDto);
        Task<RemoveEmployeeResponse> RemoveAsync(Employee employee);
    }

    public interface IUpdateEmployeeService
    {
        Task<UpdateEmployeeResponse> UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto);
    }

    public interface IUpdateEmployeeRepository
    {
        Task<Employee?> GetByIdWithInfo(UpdateEmployeeDto updateEmployeeDto);
        Task<UpdateEmployeeResponse> UpdateAsync(UpdateEmployeeDto updateEmployeeDto);
        Task<bool> DepartmentExistsAsync(int departmentId);
        Task<bool> EmailExistsAsync(int employeeId, string email);
        Task<bool> PhoneNumberExistsAsync(int employeeId, string phoneNumber);
    }

    public interface IViewEmployeeService
    {
        Task<ViewEmployeeResponse> GetEmployeeAsync(EmployeeIdDto employeeIdDto);
    }

    public interface IViewEmployeeRepository
    {
        Task<EmployeeDto?> GetAsync(EmployeeIdDto employeeIdDto);
    }

    public interface IViewAllEmployeesService
    {
        Task<ViewAllEmployeesResponse> GetAllEmployeesAsync();
    }

    public interface IViewAllEmployeesRepository
    {
        Task<List<EmployeesListDto>> GetAsync();
    }
}
