using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Resources
{
    public class ParagraphResource
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}
