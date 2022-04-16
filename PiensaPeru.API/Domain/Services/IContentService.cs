using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Services.Communications;

namespace PiensaPeru.API.Domain.Services
{
    public interface IContentService
    {
        Task<IEnumerable<Content>> ListAsync();
        Task<ContentResponse> GetByIdAsync(int id);
        Task<ContentResponse> SaveAsync(Content content);
        Task<ContentResponse> UpdateAsync(int id, Content content);
        Task<ContentResponse> DeleteAsync(int id);
    }
}
