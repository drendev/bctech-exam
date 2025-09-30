
using Application.Dto;
using Application.Response;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IAddDepartmentService
    {
        Task<AddDepartmentResponse> AddDepartmentAsync(DepartmentDto departmentDto);
    }

    public interface IAddDepartmentRepository
    {
        Task<AddDepartmentResponse> AddAsync(DepartmentDto departmentDto);
        Task<bool> DepartmentExistAsync(string departmentName);
    }

    public interface IUpdateDepartmentService
    {
        Task<UpdateDepartmentResponse> UpdateDepartmentAsync(UpdateDepartmentDto updateDepartmentDto);
    }

    public interface IUpdateDepartmentRepository
    {
        Task<UpdateDepartmentResponse> UpdateAsync(UpdateDepartmentDto updateDepartmentDto);
        Task<bool> DepartmentExistAsync(int departmentId, string departmentName);
        Task<Department?> GetByIdWithInfo(UpdateDepartmentDto updateDepartmentDto);
    }

    public interface IViewDepartmentService
    {
        Task<ViewDepartmentResponse> ViewDepartmentAsync(DepartmentIdDto departmentIdDto);
    }

    public interface IViewDepartmentRepository
    {
        Task<ViewDepartmentDto?> ViewAsync(DepartmentIdDto departmentIdDto);
    }

    public interface IViewAllDepartmentService
    {
        Task<ViewAllDepartmentsReponse> ViewAllDepartmentsAsync();
    }

    public interface IViewAllDepartmentRepository
    {
        Task<List<DepartmentListDto>> ViewAllAsync();
    }
}
