using System.Text.RegularExpressions;
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
            // Salary validation
            if (employeeDto.Salary <= 0)
                return new AddEmployeeResponse(false, "Salary must be greater than 0.");

            // Job title required and max length
            if (string.IsNullOrWhiteSpace(employeeDto.JobTitle))
                return new AddEmployeeResponse(false, "Job Title is required.");
            if (employeeDto.JobTitle.Length > 100)
                return new AddEmployeeResponse(false, "Job Title cannot exceed 100 characters.");

            // Department validation
            if (employeeDto.DepartmentId == 0)
                return new AddEmployeeResponse(false, "Department is required.");
            if (!await repository.DepartmentExistsAsync(employeeDto.DepartmentId))
                return new AddEmployeeResponse(false, "Department does not exist.");

            // Personal Info validations
            if (employeeDto.PersonalInfo is null)
                return new AddEmployeeResponse(false, "Personal Info is required.");

            if (string.IsNullOrWhiteSpace(employeeDto.PersonalInfo.FirstName))
                return new AddEmployeeResponse(false, "First Name is required.");
            if (employeeDto.PersonalInfo.FirstName.Length > 50)
                return new AddEmployeeResponse(false, "First Name cannot exceed 50 characters.");

            if (string.IsNullOrWhiteSpace(employeeDto.PersonalInfo.LastName))
                return new AddEmployeeResponse(false, "Last Name is required.");
            if (employeeDto.PersonalInfo.LastName.Length > 50)
                return new AddEmployeeResponse(false, "Last Name cannot exceed 50 characters.");

            if (string.IsNullOrWhiteSpace(employeeDto.PersonalInfo.Gender))
                return new AddEmployeeResponse(false, "Gender is required.");
            if (employeeDto.PersonalInfo.Gender.Length > 10)
                return new AddEmployeeResponse(false, "Gender cannot exceed 10 characters.");

            if (string.IsNullOrWhiteSpace(employeeDto.PersonalInfo.Address))
                return new AddEmployeeResponse(false, "Address is required.");
            if (employeeDto.PersonalInfo.Address.Length > 200)
                return new AddEmployeeResponse(false, "Address cannot exceed 200 characters.");

            if (string.IsNullOrWhiteSpace(employeeDto.PersonalInfo.PhoneNumber))
                return new AddEmployeeResponse(false, "Phone Number is required.");
            if (employeeDto.PersonalInfo.PhoneNumber.Length > 20)
                return new AddEmployeeResponse(false, "Phone Number cannot exceed 20 characters.");
            if (await repository.PhoneNumberExistsAsync(employeeDto.PersonalInfo.PhoneNumber))
                return new AddEmployeeResponse(false, "Phone Number already exists.");

            // Email validation
            if (string.IsNullOrWhiteSpace(employeeDto.PersonalInfo.Email))
                return new AddEmployeeResponse(false, "Email is required.");
            if (employeeDto.PersonalInfo.Email.Length > 100)
                return new AddEmployeeResponse(false, "Email cannot exceed 100 characters.");

            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(employeeDto.PersonalInfo.Email, emailPattern, RegexOptions.IgnoreCase))
                return new AddEmployeeResponse(false, "Invalid email format.");

            if (await repository.EmailExistsAsync(employeeDto.PersonalInfo.Email))
                return new AddEmployeeResponse(false, "Email already exists.");

            return await repository.AddAsync(employeeDto);
        }
    }
}
