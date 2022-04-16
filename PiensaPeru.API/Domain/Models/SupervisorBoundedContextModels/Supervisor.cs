using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Domain.Models
{
    public class Supervisor : Person
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
