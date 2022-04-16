using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Domain.Services.Communications
{
    public class ParagraphResponse : BaseResponse<Paragraph>
    {
        public ParagraphResponse(Paragraph resource) : base(resource)
        {
        }

        public ParagraphResponse(string message) : base(message)
        {
        }
    }
}
