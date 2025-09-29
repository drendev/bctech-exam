
using Application.Dto;
using Application.Interfaces;
using Application.Response;

namespace Application.Service
{
    public class AddEmployeeService : IAddEmployeeService
    {
        private readonly IAddEmployeeRepository repository;

        public AddEmployeeService(IAddEmployeeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AddEmployeeResponse> AddAsync(EmployeeDto employeeDto)
        {
            if (employeeDto.Salary <= 0) 
                return new AddEmployeeResponse
                    (false, "Salary must be greater than 0.");

            if (string.IsNullOrWhiteSpace(employeeDto.JobTitle))
                return new AddEmployeeResponse
                    (false, "Job Title is required.");

            if (employeeDto.DepartmentId == 0)
                return new AddEmployeeResponse
                    (false, "Department is required.");

            if (!await repository.DepartmentExistsAsync(employeeDto.DepartmentId))
                return new AddEmployeeResponse(false, "Department does not exist.");

            if (string.IsNullOrWhiteSpace(employeeDto.PersonalInfo!.FirstName))
                return new AddEmployeeResponse
                    (false, "First Name of Employee is required");

            if (string.IsNullOrWhiteSpace(employeeDto.PersonalInfo!.LastName))
                return new AddEmployeeResponse
                    (false, "Last Name of Employee is required.");

            if (string.IsNullOrWhiteSpace(employeeDto.PersonalInfo!.Gender))
                return new AddEmployeeResponse
                    (false, "Gender of Employee is required.");

            if (string.IsNullOrWhiteSpace(employeeDto.PersonalInfo!.Address))
                return new AddEmployeeResponse
                    (false, "Address of Employee is required.");

            if (string.IsNullOrWhiteSpace(employeeDto.PersonalInfo!.PhoneNumber))
                return new AddEmployeeResponse
                    (false, "Phone number of Employee is required.");

            if (await repository.PhoneNumberExistsAsync(employeeDto.PersonalInfo!.PhoneNumber))
                return new AddEmployeeResponse(false, "Phone Number already exists.");

            if (string.IsNullOrWhiteSpace(employeeDto.PersonalInfo!.Email))
                return new AddEmployeeResponse
                    (false, "Email of employee is required.");

            if (await repository.EmailExistsAsync(employeeDto.PersonalInfo!.Email))
                return new AddEmployeeResponse(false, "Email already exists.");

            return await repository.AddAsync(employeeDto);
        }
    }
}
