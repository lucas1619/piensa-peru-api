using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.API.Resources
{
    public class SaveDataTypeResource
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string? Name { get; set; }
    }
}
