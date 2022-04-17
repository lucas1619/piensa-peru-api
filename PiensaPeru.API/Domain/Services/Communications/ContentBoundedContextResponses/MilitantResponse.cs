using PiensaPeru.API.Domain.Models.ContentBoundedContextModels;

namespace PiensaPeru.API.Domain.Services.Communications.ContentBoundedContextResponses
{
    public class MilitantResponse : BaseResponse<Militant>
    {
        public MilitantResponse(Militant resource) : base(resource)
        {
        }

        public MilitantResponse(string message) : base(message)
        {
        }
    }
}
