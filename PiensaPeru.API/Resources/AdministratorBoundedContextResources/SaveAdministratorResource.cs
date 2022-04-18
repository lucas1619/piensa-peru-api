using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.API.Resources.AdministratorBoundedContextResources
{
    public class SaveAdministratorResource : SavePersonResource
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
