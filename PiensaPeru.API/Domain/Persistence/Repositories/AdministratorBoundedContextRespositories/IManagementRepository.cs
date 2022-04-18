using PiensaPeru.API.Domain.Models.AdministratorBoundedContextModels;

namespace PiensaPeru.API.Domain.Persistence.Repositories.AdministratorBoundedContextRespositories
{
    public interface IManagementRepository
    {
        Task<IEnumerable<Management>> ListAsync();
        Task<IEnumerable<Management>> ListByAdministratorIdAsync(int administratorId);
        Task<Management> FindById(int id);
        Task AddAsync(Management management);
        void Update(Management management);
        void Remove(Management management);
    }
}
