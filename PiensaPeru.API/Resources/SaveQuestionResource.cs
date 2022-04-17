using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.API.Resources
{
    public class SaveQuestionResource
    {
        [Required]
        public string? Description { get; set; }
    }
}
