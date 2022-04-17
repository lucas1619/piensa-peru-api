using PiensaPeru.API.Domain.Models.ContentBoundedContextModels;

namespace PiensaPeru.API.Domain.Services.Communications.ContentBoundedContextResponses
{
    public class MilitantContentResponse : BaseResponse<MilitantContent>
    {
        public MilitantContentResponse(MilitantContent resource) : base(resource)
        {
        }
        
        public MilitantContentResponse(string message) : base(message)
        {
        }
    }
}
