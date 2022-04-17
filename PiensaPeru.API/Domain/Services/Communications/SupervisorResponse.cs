using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Domain.Services.Communications
{
    public class SupervisorResponse : BaseResponse<Supervisor>
    {
        public SupervisorResponse(Supervisor resource) : base(resource)
        {
        }

        public SupervisorResponse(string message) : base(message)
        {
        }
    }
}
