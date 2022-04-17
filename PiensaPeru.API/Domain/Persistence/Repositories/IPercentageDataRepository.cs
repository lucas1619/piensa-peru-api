using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Domain.Persistence.Repositories
{
    public interface IPercentageDataRepository
    {
        Task<IEnumerable<PercentageData>> ListAsync();
        Task<PercentageData> FindById(int id);
        Task AddAsync(PercentageData percentageData);
        void Update(PercentageData percentageData);
        void Remove(PercentageData percentageData);
    }
}
