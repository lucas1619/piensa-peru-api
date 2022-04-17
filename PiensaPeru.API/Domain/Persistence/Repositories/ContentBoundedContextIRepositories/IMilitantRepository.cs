using PiensaPeru.API.Domain.Models.ContentBoundedContextModels;

namespace PiensaPeru.API.Domain.Persistence.Repositories.ContentBoundedContextIRepositories
{
    public interface IMilitantRepository
    {
        Task<IEnumerable<Militant>> ListAsync();
        Task<Militant> FindById(int id);
        Task AddAsync(Militant militant);
        void Update(Militant militant);
        void Remove(Militant militant);
    }
}
