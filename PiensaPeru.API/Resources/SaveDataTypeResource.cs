using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.API.Resources
{
    public class SaveDataTypeResource
    {
        [Required]
        [EmailAddress]
        public string? Name { get; set; }
    }
}
