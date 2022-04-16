using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Domain.Services.Communications
{
    public class QuestionResponse : BaseResponse<Question>
    {
        public QuestionResponse(Question resource) : base(resource)
        {
        }

        public QuestionResponse(string message) : base(message)
        {
        }
    }
}
