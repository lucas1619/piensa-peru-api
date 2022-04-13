using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Domain.Persistence.Repositories
{
    public interface ISupervisorRepository
    {
        Task<IEnumerable<Supervisor>> ListAsync();
        Task<IEnumerable<Supervisor>> ListByPersonIdAsync(int personId);
        Task<Supervisor> FindByPersonId(int personId);
        Task AddAsync(Supervisor supervisor);
        void Update(Supervisor supervisor);
    }
}
