using PiensaPeru.API.Domain.Models.ContentBoundedContextModels;

namespace PiensaPeru.API.Domain.Services.Communications.ContentBoundedContextResponses
{
    public class MilitantTypeResponse : BaseResponse<MilitantType>
    {
        public MilitantTypeResponse(MilitantType resource) : base(resource)
        {
        }

        public MilitantTypeResponse(string message) : base(message)
        {
        }
    }
}
