using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Resources
{
    public class ImageResource
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
    }
}
