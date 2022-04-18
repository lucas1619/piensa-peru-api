using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.API.Resources.ContentBoundedContextResources
{
    public class SavePoliticalPartyResource
    {
        [Required]
        [MaxLength(255)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string? PresidentName { get; set; }
        [Required]
        public DateTime FoundationDate { get; set; }
        [Required]
        [MaxLength(255)]
        public string? Ideology { get; set; }
        [Required]
        [MaxLength(255)]
        public string? Position { get; set; }
        [Required]
        [MaxLength(255)]
        public string? PictureLink { get; set; }
    }
}
