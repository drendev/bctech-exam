
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class EmployeePersonalInfo
    {
        [Key, ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; } = null!;

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; } = DateTime.Now;
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
