
using Application.Dto;
using Application.Interfaces;
using Application.Response;

namespace Application.Service
{
    public class AddDepartmentService : IAddDepartmentService
    {
        private readonly IAddDepartmentRepository repository;

        public AddDepartmentService(IAddDepartmentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AddDepartmentResponse> AddDepartmentAsync(DepartmentDto departmentDto)
        {
            if (string.IsNullOrWhiteSpace(departmentDto.Name))
                return new AddDepartmentResponse(false, "Department Name is required.");

            if (await repository.DepartmentExistAsync(departmentDto.Name))
                return new AddDepartmentResponse(false, "Department Name Already Exist.");

            if (string.IsNullOrWhiteSpace(departmentDto.Location))
                return new AddDepartmentResponse(false, "Department Location is required.");

            return await repository.AddAsync(departmentDto);
        }
    }
}
