using System.Text.RegularExpressions;
using Application.Dto;
using Application.Interfaces;
using Application.Response;

namespace Application.Service
{
    public class UpdateEmployeeService : IUpdateEmployeeService
    {
        private readonly IUpdateEmployeeRepository repository;

        public UpdateEmployeeService(IUpdateEmployeeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<UpdateEmployeeResponse> UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = await repository.GetByIdWithInfo(updateEmployeeDto);
            if (employee == null)
            {
                return new UpdateEmployeeResponse(false, "Employee Not Found");
            }

            // Salary
            if (updateEmployeeDto.Salary <= 0)
                return new UpdateEmployeeResponse(false, "Salary must be greater than 0.");

            // Job Title
            if (string.IsNullOrWhiteSpace(updateEmployeeDto.JobTitle))
                return new UpdateEmployeeResponse(false, "Job Title is required.");
            if (updateEmployeeDto.JobTitle.Length > 100)
                return new UpdateEmployeeResponse(false, "Job Title cannot exceed 100 characters.");

            // Department
            if (updateEmployeeDto.DepartmentId == 0)
                return new UpdateEmployeeResponse(false, "Department is required.");
            if (!await repository.DepartmentExistsAsync(updateEmployeeDto.DepartmentId))
                return new UpdateEmployeeResponse(false, "Department does not exist.");

            // Personal Info
            if (updateEmployeeDto.PersonalInfo != null)
            {
                // First Name
                if (string.IsNullOrWhiteSpace(updateEmployeeDto.PersonalInfo.FirstName))
                    return new UpdateEmployeeResponse(false, "First Name is required.");
                if (updateEmployeeDto.PersonalInfo.FirstName.Length > 50)
                    return new UpdateEmployeeResponse(false, "First Name cannot exceed 50 characters.");

                // Last Name
                if (string.IsNullOrWhiteSpace(updateEmployeeDto.PersonalInfo.LastName))
                    return new UpdateEmployeeResponse(false, "Last Name is required.");
                if (updateEmployeeDto.PersonalInfo.LastName.Length > 50)
                    return new UpdateEmployeeResponse(false, "Last Name cannot exceed 50 characters.");

                // Gender
                if (string.IsNullOrWhiteSpace(updateEmployeeDto.PersonalInfo.Gender))
                    return new UpdateEmployeeResponse(false, "Gender is required.");
                if (updateEmployeeDto.PersonalInfo.Gender.Length > 10)
                    return new UpdateEmployeeResponse(false, "Gender cannot exceed 10 characters.");

                // Address
                if (string.IsNullOrWhiteSpace(updateEmployeeDto.PersonalInfo.Address))
                    return new UpdateEmployeeResponse(false, "Address is required.");
                if (updateEmployeeDto.PersonalInfo.Address.Length > 200)
                    return new UpdateEmployeeResponse(false, "Address cannot exceed 200 characters.");

                // Phone Number
                if (string.IsNullOrWhiteSpace(updateEmployeeDto.PersonalInfo.PhoneNumber))
                    return new UpdateEmployeeResponse(false, "Phone Number is required.");
                if (updateEmployeeDto.PersonalInfo.PhoneNumber.Length > 20)
                    return new UpdateEmployeeResponse(false, "Phone Number cannot exceed 20 characters.");
                if (await repository.PhoneNumberExistsAsync(updateEmployeeDto.EmployeeId, updateEmployeeDto.PersonalInfo.PhoneNumber))
                    return new UpdateEmployeeResponse(false, "Phone Number already exists.");

                // Email
                if (string.IsNullOrWhiteSpace(updateEmployeeDto.PersonalInfo.Email))
                    return new UpdateEmployeeResponse(false, "Email is required.");
                if (updateEmployeeDto.PersonalInfo.Email.Length > 100)
                    return new UpdateEmployeeResponse(false, "Email cannot exceed 100 characters.");

                // Email format check
                var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(updateEmployeeDto.PersonalInfo.Email, emailPattern, RegexOptions.IgnoreCase))
                    return new UpdateEmployeeResponse(false, "Invalid email format.");

                if (await repository.EmailExistsAsync(updateEmployeeDto.EmployeeId, updateEmployeeDto.PersonalInfo.Email))
                    return new UpdateEmployeeResponse(false, "Email already exists.");
            }

            return await repository.UpdateAsync(updateEmployeeDto);
        }
    }
}
