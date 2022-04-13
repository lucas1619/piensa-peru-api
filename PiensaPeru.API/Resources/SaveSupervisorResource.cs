using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.API.Resources
{
    public class SaveSupervisorResource
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Password { get; set; }
    }
}
