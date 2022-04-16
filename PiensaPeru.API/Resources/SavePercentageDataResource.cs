using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.API.Resources
{
    public class SavePercentageDataResource
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        [MaxLength(255)]
        public string? Description { get; set; }
        [Required]
        public int ContentId { get; set; }
    }
}
