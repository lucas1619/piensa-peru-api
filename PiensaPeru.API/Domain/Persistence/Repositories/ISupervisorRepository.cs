using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Domain.Persistence.Repositories
{
    public interface ISupervisorRepository
    {
        Task<IEnumerable<Supervisor>> ListAsync();
        Task<Supervisor> FindById(int id);
        Task AddAsync(Supervisor supervisor);
        void Update(Supervisor supervisor);
        void Remove(Supervisor supervisor);
    }
}
