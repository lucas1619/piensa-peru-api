using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.API.Resources
{
    public class SavePostResource
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? AuthorName { get; set; }
        [Required]
        public string? Tag { get; set; }
    }
}
