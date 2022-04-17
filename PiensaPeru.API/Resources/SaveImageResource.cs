using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.API.Resources
{
    public class SaveImageResource
    {
        [Required]
        [MaxLength(255)]
        public string? Url { get; set; }
    }
}
