
using Application.Dto;
using Application.Interfaces;
using Application.Response;

namespace Application.Service
{
    public class ViewEmployeeService : IViewEmployeeService
    {
        private readonly IViewEmployeeRepository repository;

        public ViewEmployeeService(IViewEmployeeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ViewEmployeeResponse> GetEmployeeAsync(EmployeeIdDto employeeIdDto)
        {
            var employee = await repository.GetAsync(employeeIdDto);

            if (employee == null)
                return new ViewEmployeeResponse(false, "Employee Not Found.");

            return new ViewEmployeeResponse(true, "Employee data retrieved successfully", employee);
        }
    }
}
