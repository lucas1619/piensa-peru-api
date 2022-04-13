using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Domain.Models
{
    public class Supervisor
    {
        public int PersonId { get; set; }
        public Person? Person { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

    }
}
