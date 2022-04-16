using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Domain.Services.Communications
{
    public class ImageResponse : BaseResponse<Image>
    {
        public ImageResponse(Image resource) : base(resource)
        {
        }

        public ImageResponse(string message) : base(message)
        {
        }
    }
}
