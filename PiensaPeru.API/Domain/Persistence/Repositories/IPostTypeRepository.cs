using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Domain.Persistence.Repositories
{
    public interface IPostTypeRepository
    {
        Task<IEnumerable<PostType>> ListAsync();
        Task<PostType> FindById(int id);
        Task AddAsync(PostType postType);
        void Update(PostType postType);
        void Remove(PostType postType);
    }
}
