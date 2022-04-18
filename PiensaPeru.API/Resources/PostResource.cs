namespace PiensaPeru.API.Resources
{
    public class PostResource
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? AuthorName { get; set; }
        public string? Tag { get; set; }
        public int PostTypeId { get; set; }
        public int ContentId { get; set; }
        public int SupervisorId { get; set; }
    }
}
