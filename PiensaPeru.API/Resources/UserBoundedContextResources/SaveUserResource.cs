using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.API.Resources.UserBoundedContextResources
{
    public class SaveUserResource : SavePersonResource
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public bool Subscribed { get; set; }
    }
}
