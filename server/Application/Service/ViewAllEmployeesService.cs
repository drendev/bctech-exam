
using Application.Interfaces;
using Application.Response;

namespace Application.Service
{
    public class ViewAllEmployeesService : IViewAllEmployeesService
    {
        private readonly IViewAllEmployeesRepository repository;

        public ViewAllEmployeesService(IViewAllEmployeesRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ViewAllEmployeesResponse> GetAllEmployeesAsync()
        {
            var employees = await repository.GetAsync();

            if (employees == null || !employees.Any())
                return new ViewAllEmployeesResponse(false, "No employees found.");

            return new ViewAllEmployeesResponse(true, "Employees retrieved successfully", employees);
        }
    }
}
