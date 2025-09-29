
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
