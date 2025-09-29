
namespace Application.Response
{
    public record AddEmployeeResponse(bool Response, string Message = null!);
    public record RemoveEmployeeResponse(bool Success, string Message = null!);
}
