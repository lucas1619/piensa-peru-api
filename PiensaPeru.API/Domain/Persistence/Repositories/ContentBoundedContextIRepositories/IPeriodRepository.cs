using PiensaPeru.API.Domain.Models.ContentBoundedContextModels;

namespace PiensaPeru.API.Domain.Persistence.Repositories.ContentBoundedContextIRepositories
{
    public interface IPeriodRepository
    {
        Task<IEnumerable<Period>> ListAsync();
        Task<Period> FindById(int id);
        Task AddAsync(Period period);
        void Update(Period period);
        void Remove(Period period);
    }
}
