
using Application.Dto;

namespace Application.Response
{
    public record AddEmployeeResponse(bool Response, string Message = null!);
    public record RemoveEmployeeResponse(bool Success, string Message = null!);
    public record UpdateEmployeeResponse(bool Sucess, string Message = null!, UpdateEmployeeDto? employee = null!);
    public record ViewEmployeeResponse(bool Success, string Message = null!, EmployeeDto? employee = null!);
    public record ViewAllEmployeesResponse(bool Success, string Message = null!, List<EmployeesListDto?> Employees = null!);
}
