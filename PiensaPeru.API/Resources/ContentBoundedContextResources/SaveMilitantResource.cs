using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.API.Resources.ContentBoundedContextResources
{
    public class SaveMilitantResource : SavePersonResource
    {
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public DateTime BirthPlace { get; set; }
        [Required]
        [MaxLength(255)]
        public string? Profession { get; set; }
        [Required]
        public int PolitcalPartyId { get; set; }
        [Required]
        [MaxLength(255)]
        public string? PictureLink { get; set; }
        [Required]
        public bool IsPresident { get; set; }
        [Required]
        public int MilitantTypeId { get; set; }
    }
}
