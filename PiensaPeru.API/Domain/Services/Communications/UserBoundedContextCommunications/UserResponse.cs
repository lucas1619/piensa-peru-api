using PiensaPeru.API.Domain.Models.UserBoundedContextModels;

namespace PiensaPeru.API.Domain.Services.Communications.UserBoundedContextCommunications
{
    public class UserResponse : BaseResponse<User>
    {
        public UserResponse(User resource) : base(resource)
        {
        }

        public UserResponse(string message) : base(message)
        {
        }
    }
}
