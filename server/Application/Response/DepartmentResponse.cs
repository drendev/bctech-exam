
using Application.Dto;

namespace Application.Response
{
    public record AddDepartmentResponse(bool Success, string Message = null!);
    public record UpdateDepartmentResponse(bool Success, string Message = null!, UpdateDepartmentDto department = null!);
    public record ViewDepartmentResponse(bool Success, string Message = null!, ViewDepartmentDto? department = null!);
    public record ViewAllDepartmentsReponse(bool Success, string Message = null!, List<DepartmentListDto?> departments = null!);
}
