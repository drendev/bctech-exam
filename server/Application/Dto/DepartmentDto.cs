
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
}
