namespace PiensaPeru.API.Domain.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? AuthorName { get; set; }
        public string? Tag { get; set; }
        public DateTime PostedAt { get; set; } = DateTime.Now;

        public int PostTypeId { get; set; }
        public PostType? PostType { get; set; }
        public int ContentId { get; set; }
        public Content? Content { get; set; }
        public int SupervisorId { get; set; }
        public Supervisor? Supervisor { get; set; }
        public ICollection<Image>? Images { get; set; }
        public ICollection<Paragraph>? Paragraphs { get; set; }

    }
}
