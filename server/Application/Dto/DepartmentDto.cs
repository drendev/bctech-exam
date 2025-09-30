
using System.ComponentModel.DataAnnotations;

namespace Application.Dto
{
    public class DepartmentDto()
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Location { get; set; }
    }

    public class UpdateDepartmentDto()
    {
        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Location { get; set; }
    }

    public class DepartmentIdDto()
    {
        [Required]
        public int DepartmentId { get; set; }
    }

    public class ViewDepartmentDto()
    {
        public string? Name { get; set; }
        public string? Location { get; set; }

        public List<EmployeesListDto?> Employees { get; set; } = new();
    }

    public class DepartmentListDto()
    {
        public int DepartmentId { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
    }
}
