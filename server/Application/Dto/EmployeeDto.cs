
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

        [Required]
        public PersonalInfoDto? PersonalInfo { get; set; }
    }

    public class EmployeeIdDto()
    {
        public int EmployeeId { get; set; }
    }
}
