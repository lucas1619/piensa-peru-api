using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Domain.Persistence.Repositories
{
    public interface IImageRepository
    {
        Task<IEnumerable<Image>> ListAsync();
        Task<Image> FindById(int id);
        Task AddAsync(Image image);
        void Update(Image image);
        void Remove(Image image);
    }
}
