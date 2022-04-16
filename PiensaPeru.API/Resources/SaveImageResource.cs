using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.API.Resources
{
    public class SaveImageResource
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string? Url { get; set; }
    }
}
