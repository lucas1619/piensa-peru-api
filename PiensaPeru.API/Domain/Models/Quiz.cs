namespace PiensaPeru.API.Domain.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public int PostId { get; set; }
        public Post? Post { get; set; }
        public ICollection<Question>? Questions { get; set; }
    }
}
