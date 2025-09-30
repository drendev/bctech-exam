
using Application.Dto;
using Application.Interfaces;
using Application.Response;

namespace Application.Service
{
    public class ViewDepartmentService : IViewDepartmentService
    {
        private readonly IViewDepartmentRepository repository;

        public ViewDepartmentService(IViewDepartmentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ViewDepartmentResponse> ViewDepartmentAsync(DepartmentIdDto departmentIdDto)
        {
            var department = await repository.ViewAsync(departmentIdDto);

            if (department == null)
                return new ViewDepartmentResponse(false, "Department Not Found.");

            return new ViewDepartmentResponse(true, "Department data retrieved successfully.", department);
        }
    }
}
