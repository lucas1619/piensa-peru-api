using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Domain.Services.Communications
{
    public class ContentResponse : BaseResponse<Content>
    {
        public ContentResponse(Content resource) : base(resource)
        {
        }

        public ContentResponse(string message) : base(message)
        {
        }
    }
}
