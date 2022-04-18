using PiensaPeru.API.Domain.Models.AdministratorBoundedContextModels;

namespace PiensaPeru.API.Domain.Persistence.Repositories.AdministratorBoundedContextRespositories
{
    public interface IAdministratorRepository
    {
        Task<IEnumerable<Administrator>> ListAsync();
        Task<Administrator> FindById(int id);
        Task AddAsync(Administrator administrator);
        void Update(Administrator administrator);
        void Remove(Administrator administrator);
    }
}
