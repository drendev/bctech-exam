
using System.ComponentModel.DataAnnotations;

namespace Application.Dto
{
    public class PersonalInfoDto()
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string? Gender { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }

        [Required]
        public string? Email { get; set; }
    }
}
