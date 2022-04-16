using PiensaPeru.API.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.API.Resources
{
    public class SavePostTypeResource
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string? Name { get; set; }
    }
}
