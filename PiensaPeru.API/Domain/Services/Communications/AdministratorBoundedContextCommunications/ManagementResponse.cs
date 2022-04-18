using PiensaPeru.API.Domain.Models.AdministratorBoundedContextModels;

namespace PiensaPeru.API.Domain.Services.Communications.AdministratorBoundedContextCommunications
{
    public class ManagementResponse : BaseResponse<Management>
    {
        public ManagementResponse(Management resource) : base(resource)
        {
        }

        public ManagementResponse(string message) : base(message)
        {
        }
    }
}
