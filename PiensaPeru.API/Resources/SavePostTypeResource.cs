using PiensaPeru.API.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.API.Resources
{
    public class SavePostTypeResource
    {
        [Required]
        [MaxLength(255)]
        public string? Name { get; set; }
    }
}
