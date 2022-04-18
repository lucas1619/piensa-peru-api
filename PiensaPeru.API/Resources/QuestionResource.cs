namespace PiensaPeru.API.Resources
{
    public class QuestionResource
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int QuizId { get; set; }
    }
}
