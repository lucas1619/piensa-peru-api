using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Services.Communications;

namespace PiensaPeru.API.Domain.Services
{
    public interface ISupervisorService
    {
        Task<IEnumerable<Supervisor>> ListAsync();
        Task<SupervisorResponse> GetByIdAsync(int id);
        Task<SupervisorResponse> SaveAsync(int personId, Supervisor supervisor);
        Task<SupervisorResponse> UpdateAsync(int id, Supervisor supervisor);
    }
}
