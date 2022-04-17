using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Domain.Persistence.Repositories
{
    public interface IContentRepository
    {
        Task<IEnumerable<Content>> ListAsync();
        Task<Content> FindById(int id);
        Task AddAsync(Content content);
        void Update(Content content);
        void Remove(Content content);
    }
}
