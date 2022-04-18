using PiensaPeru.API.Domain.Models.UserBoundedContextModels;
using PiensaPeru.API.Domain.Services.Communications.UserBoundedContextCommunications;

namespace PiensaPeru.API.Domain.Services.UserBoundedContextServices
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
        Task<UserResponse> GetByIdAsync(int id);
        Task<UserResponse> SaveAsync(User user);
        Task<UserResponse> UpdateAsync(int id, User user);
        Task<UserResponse> DeleteAsync(int id);
    }
}
