using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Services.Communications;

namespace PiensaPeru.API.Domain.Services
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> ListAsync();
        Task<IEnumerable<Post>> ListBySupervisorIdAsync(int supervisorId);
        Task<PostResponse> GetByIdAsync(int id);
        Task<PostResponse> SaveAsync(int supervisorId, int contentId, Post post);
        Task<PostResponse> UpdateAsync(int id, Post post);
        Task<PostResponse> DeleteAsync(int id);
    }
}
