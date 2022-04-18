using PiensaPeru.API.Domain.Models.UserBoundedContextModels;

namespace PiensaPeru.API.Domain.Services.Communications.UserBoundedContextCommunications
{
    public class PlanResponse : BaseResponse<Plan>
    {
        public PlanResponse(Plan resource) : base(resource)
        {
        }

        public PlanResponse(string message) : base(message)
        {
        }
    }
}
