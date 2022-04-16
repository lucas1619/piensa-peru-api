using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.API.Resources
{
    public class SaveParagraphResource
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string? Title { get; set; }
        [Required]
        [MaxLength(255)]        
        public string? Content { get; set; }
        [Required]
        public int PostId { get; set; }
    }
}
