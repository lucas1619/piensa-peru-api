using PiensaPeru.API.Domain.Models.ContentBoundedContextModels;

namespace PiensaPeru.API.Domain.Services.Communications.ContentBoundedContextResponses
{
    public class PeriodResponse : BaseResponse<Period>
    {
        public PeriodResponse(Period resource) : base(resource)
        {
        }

        public PeriodResponse(string message) : base(message)
        {
        }
    }
}
