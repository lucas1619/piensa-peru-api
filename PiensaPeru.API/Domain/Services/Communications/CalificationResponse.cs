using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Domain.Services.Communications
{
    public class CalificationResponse : BaseResponse<Calification>
    {
        public CalificationResponse(Calification resource) : base(resource)
        {
        }

        public CalificationResponse(string message) : base(message)
        {
        }
    }
}
