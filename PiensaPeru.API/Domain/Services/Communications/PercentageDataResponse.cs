using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Domain.Services.Communications
{
    public class PercentageDataResponse : BaseResponse<PercentageData>
    {
        public PercentageDataResponse(PercentageData resource) : base(resource)
        {
        }

        public PercentageDataResponse(string message) : base(message)
        {
        }
    }
}
