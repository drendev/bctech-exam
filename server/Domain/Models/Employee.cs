
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string? JobTitle { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;

        public EmployeePersonalInfo PersonalInfo { get; set; } = null!;
    }
}
