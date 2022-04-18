using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.API.Resources.ContentBoundedContextResources
{
    public class SavePeriodResource
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string? OriginOfCharge { get; set; }
    }
}
