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

            if (updateEmployeeDto.Salary <= 0)
                return new UpdateEmployeeResponse(false, "Salary must be greater than 0.");

            if (string.IsNullOrWhiteSpace(updateEmployeeDto.JobTitle))
                return new UpdateEmployeeResponse(false, "Job Title is required.");

            if (updateEmployeeDto.DepartmentId == 0)
                return new UpdateEmployeeResponse(false, "Department is required.");

            if (!await repository.DepartmentExistsAsync(updateEmployeeDto.DepartmentId))
                return new UpdateEmployeeResponse(false, "Department does not exist.");

            if (updateEmployeeDto.PersonalInfo != null)
            {
                if (string.IsNullOrWhiteSpace(updateEmployeeDto.PersonalInfo.FirstName))
                    return new UpdateEmployeeResponse(false, "First Name of Employee is required.");

                if (string.IsNullOrWhiteSpace(updateEmployeeDto.PersonalInfo.LastName))
                    return new UpdateEmployeeResponse(false, "Last Name of Employee is required.");

                if (string.IsNullOrWhiteSpace(updateEmployeeDto.PersonalInfo.Gender))
                    return new UpdateEmployeeResponse(false, "Gender of Employee is required.");

                if (string.IsNullOrWhiteSpace(updateEmployeeDto.PersonalInfo.Address))
                    return new UpdateEmployeeResponse(false, "Address of Employee is required.");

                if (string.IsNullOrWhiteSpace(updateEmployeeDto.PersonalInfo.PhoneNumber))
                    return new UpdateEmployeeResponse(false, "Phone Number of Employee is required.");

                if (await repository.PhoneNumberExistsAsync(updateEmployeeDto.EmployeeId, updateEmployeeDto.PersonalInfo.PhoneNumber))
                    return new UpdateEmployeeResponse(false, "Phone Number already exists.");

                if (string.IsNullOrWhiteSpace(updateEmployeeDto.PersonalInfo.Email))
                    return new UpdateEmployeeResponse(false, "Email of Employee is required.");

                if (await repository.EmailExistsAsync(updateEmployeeDto.EmployeeId, updateEmployeeDto.PersonalInfo.Email))
                    return new UpdateEmployeeResponse(false, "Email already exists.");
            }

            return await repository.UpdateAsync(updateEmployeeDto);
        }
    }
}
