

using Application.Dto;
using Application.Interfaces;
using Application.Response;

namespace Application.Service
{
    public class RemoveEmployeeService : IRemoveEmployeeService
    {
        private readonly IRemoveEmployeeRepository repository;

        public RemoveEmployeeService(IRemoveEmployeeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<RemoveEmployeeResponse> RemoveEmployeeAsync(EmployeeIdDto employeeIdDto)
        {
            var employee = await repository.GetByIdAsync(employeeIdDto);
            if (employee == null) 
                return new RemoveEmployeeResponse
                    (false, "Employee not found.");

            return await repository.RemoveAsync(employee);
        }
    }
}
