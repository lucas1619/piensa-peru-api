using PiensaPeru.API.Domain.Models.ContentBoundedContextModels;

namespace PiensaPeru.API.Domain.Services.Communications.ContentBoundedContextResponses
{
    public class PoliticalPartyResponse : BaseResponse<PoliticalParty>
    {
        public PoliticalPartyResponse(PoliticalParty resource) : base(resource)
        {
        }

        public PoliticalPartyResponse(string message) : base(message)
        {
        }
    }
}
