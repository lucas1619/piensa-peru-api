using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.API.Resources
{
    public class SaveContentResource
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public bool Active { get; set; } = false;
    }
}
