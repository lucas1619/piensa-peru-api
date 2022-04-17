using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.API.Resources
{
    public class SaveContentResource
    {
        [Required]
        public bool Active { get; set; } = false;
    }
}
