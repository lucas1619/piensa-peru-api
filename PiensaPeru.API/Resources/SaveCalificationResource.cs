using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.API.Resources
{
    public class SaveCalificationResource
    {
        [Required]
        public int Score { get; set; }
    }
}
