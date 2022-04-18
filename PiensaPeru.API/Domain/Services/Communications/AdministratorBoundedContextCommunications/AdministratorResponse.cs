using PiensaPeru.API.Domain.Models.AdministratorBoundedContextModels;

namespace PiensaPeru.API.Domain.Services.Communications.AdministratorBoundedContextCommunications
{
    public class AdministratorResponse : BaseResponse<Administrator>
    {
        public AdministratorResponse(Administrator resource) : base(resource)
        {
        }

        public AdministratorResponse(string message) : base(message)
        {
        }
    }
}
