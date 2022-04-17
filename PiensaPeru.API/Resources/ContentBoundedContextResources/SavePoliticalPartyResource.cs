using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.API.Resources.ContentBoundedContextResources
{
    public class SavePoliticalPartyResource
    {
        [Required]
        [MaxLength(255)]
        string Name { get; set; }
        [Required]
        [MaxLength(255)]
        string PresidentName { get; set; }
        [Required]
        DateTime FoundationDate { get; set; }
        [Required]
        [MaxLength(255)]
        string Ideology { get; set; }
        [Required]
        [MaxLength(255)]
        string Position { get; set; }
        [Required]
        [MaxLength(255)]
        string PictureLink { get; set; }
    }
}
