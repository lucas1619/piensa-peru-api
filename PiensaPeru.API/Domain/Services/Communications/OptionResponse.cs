using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Domain.Services.Communications
{
    public class OptionResponse : BaseResponse<Option>
    {
        public OptionResponse(Option resource) : base(resource)
        {
        }

        public OptionResponse(string message) : base(message)
        {
        }
    }
}
