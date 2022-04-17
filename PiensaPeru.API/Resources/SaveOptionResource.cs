using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.API.Resources
{
    public class SaveOptionResource
    {
        [Required]
        public string? Description { get; set; }
        [Required]
        public bool IsAnswer { get; set; }
    }
}
