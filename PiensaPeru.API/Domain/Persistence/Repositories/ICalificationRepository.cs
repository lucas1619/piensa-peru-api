using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Domain.Persistence.Repositories
{
    public interface ICalificationRepository
    {
        Task<IEnumerable<Calification>> ListAsync();
        Task<IEnumerable<Calification>> ListByUserIdAsync(int userId);
        Task<Calification> FindById(int id);
        Task AddAsync(Calification calification);
        void Update(Calification calification);
        void Remove(Calification calification);
    }
}
