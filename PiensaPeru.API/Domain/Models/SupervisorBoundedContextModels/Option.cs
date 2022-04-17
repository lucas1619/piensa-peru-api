namespace PiensaPeru.API.Domain.Models
{
    public class Option
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public bool IsAnswer { get; set; }

        public int QuestionId { get; set; }
        public Question? Question { get; set; }
    }
}
