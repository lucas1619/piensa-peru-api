using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.API.Resources
{
    public class SaveQuizResource
    {
        [Required]
        public string? Title { get; set; }
    }
}
