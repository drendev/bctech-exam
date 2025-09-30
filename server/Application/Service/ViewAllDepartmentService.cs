
using Application.Interfaces;
using Application.Response;

namespace Application.Service
{
    public class ViewAllDepartmentService : IViewAllDepartmentService
    {
        private readonly IViewAllDepartmentRepository repository;

        public ViewAllDepartmentService(IViewAllDepartmentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ViewAllDepartmentsReponse> ViewAllDepartmentsAsync()
        {
            var departments = await repository.ViewAllAsync();

            if (departments == null || !departments.Any())
                return new ViewAllDepartmentsReponse(false, "No departments Found.");

            return new ViewAllDepartmentsReponse(true, "Departments retrieved successfully.", departments!);
        }
    }
}
