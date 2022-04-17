using PiensaPeru.API.Domain.Models.ContentBoundedContextModels;

namespace PiensaPeru.API.Domain.Persistence.Repositories.ContentBoundedContextIRepositories
{
    public interface IMilitantTypeRepository
    {
        Task<IEnumerable<MilitantType>> ListAsync();
        Task<MilitantType> FindById(int id);
        Task AddAsync(MilitantType militantType);
        void Update(MilitantType militantType);
        void Remove(MilitantType militantType);
    }
}
