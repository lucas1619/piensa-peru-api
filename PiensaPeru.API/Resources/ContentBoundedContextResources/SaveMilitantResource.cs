using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.API.Resources.ContentBoundedContextResources
{
    public class SaveMilitantResource : SavePersonResource
    {
        [Required]
        DateTime BirthDate { get; set; }
        [Required]
        DateTime BirthPlace { get; set; }
        [Required]
        [MaxLength(255)]
        string? Profession { get; set; }
        [Required]
        int PolitcalPartyId { get; set; }
        [Required]
        [MaxLength(255)]
        string? PictureLink { get; set; }
        [Required]
        bool IsPresident { get; set; }
        [Required]
        int MilitantTypeId { get; set; }
    }
}
