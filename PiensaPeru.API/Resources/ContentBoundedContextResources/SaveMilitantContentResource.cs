using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.API.Resources.ContentBoundedContextResources
{
    public class SaveMilitantContentResource
    {
        [Required]
        public int MilitantId { get; set; }
        [Required]
        public int ContentId { get; set; }
        [Required]
        public int PeriodId { get; set; }
    }
}
