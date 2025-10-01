using Application.Dto;
using Application.Interfaces;
using Application.Response;

namespace Application.Service
{
    public class UpdateDepartmentService : IUpdateDepartmentService
    {
        private readonly IUpdateDepartmentRepository repository;

        public UpdateDepartmentService(IUpdateDepartmentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<UpdateDepartmentResponse> UpdateDepartmentAsync(UpdateDepartmentDto updateDepartmentDto)
        {
            var department = await repository.GetByIdWithInfo(updateDepartmentDto);

            if (department == null)
            {
                return new UpdateDepartmentResponse(false, "Department Not Found.");
            }

            if (string.IsNullOrWhiteSpace(updateDepartmentDto.Name))
                return new UpdateDepartmentResponse(false, "Department Name is required.");

            if (updateDepartmentDto.Name.Length > 60)
                return new UpdateDepartmentResponse(false, "Department Name cannot exceed 60 characters.");

            if (await repository.DepartmentExistAsync(updateDepartmentDto.DepartmentId, updateDepartmentDto.Name))
                return new UpdateDepartmentResponse(false, "Department Name already exists.");

            if (string.IsNullOrWhiteSpace(updateDepartmentDto.Location))
                return new UpdateDepartmentResponse(false, "Department Location is required.");

            if (updateDepartmentDto.Location.Length > 100)
                return new UpdateDepartmentResponse(false, "Department Location cannot exceed 100 characters.");

            return await repository.UpdateAsync(updateDepartmentDto);
        }
    }
}
