using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Resources
{
    public class PostTypeResource
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Post>? Posts { get; set; }
    }
}
