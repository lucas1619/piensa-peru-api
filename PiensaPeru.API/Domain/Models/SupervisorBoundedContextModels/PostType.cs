namespace PiensaPeru.API.Domain.Models
{
    public class PostType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Post>? Posts { get; set; }
    }
}
