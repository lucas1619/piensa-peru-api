using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.API.Resources.ContentBoundedContextResources
{
    public class SavePeriodResource
    {
        [Required]
        DateTime StartDate { get; set; }
        [Required]
        DateTime EndDate { get; set; }
        [Required]
        string? OriginOfCharge { get; set; }
    }
}
