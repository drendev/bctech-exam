
using System.ComponentModel.DataAnnotations;

namespace Application.Dto
{
    public class EmployeeDto()
    {
        [Required]
        public string? JobTitle { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; } = "Test";

        [Required]
        public PersonalInfoDto? PersonalInfo { get; set; }
    }

    public class EmployeeIdDto()
    {
        public int EmployeeId { get; set; }
    }

    public class UpdateEmployeeDto()
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public string? JobTitle { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public PersonalInfoDto? PersonalInfo { get; set; }
    }

    public class EmployeesListDto()
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DepartmentName { get; set; }
        public string? JobTitle { get; set; }
        public bool IsActive { get; set; }
    }
}
