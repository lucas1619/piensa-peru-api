using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Domain.Services.Communications
{
    public class PostResponse : BaseResponse<Post>
    {
        public PostResponse(Post resource) : base(resource)
        {
        }

        public PostResponse(string message) : base(message)
        {
        }
    }
}
