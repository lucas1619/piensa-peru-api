using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Domain.Services.Communications
{
    public class QuizResponse : BaseResponse<Quiz>
    {
        public QuizResponse(Quiz resource) : base(resource)
        {
        }

        public QuizResponse(string message) : base(message)
        {
        }
    }
}
