using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Domain.Services.Communications
{
    public class PostTypeResponse : BaseResponse<PostType>
    {
        public PostTypeResponse(PostType resource) : base(resource)
        {
        }

        public PostTypeResponse(string message) : base(message)
        {
        }
    }
}
