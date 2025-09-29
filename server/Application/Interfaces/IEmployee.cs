
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
}
