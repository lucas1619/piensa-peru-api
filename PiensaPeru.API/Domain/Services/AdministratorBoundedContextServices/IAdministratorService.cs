using PiensaPeru.API.Domain.Models.AdministratorBoundedContextModels;
using PiensaPeru.API.Domain.Services.Communications.AdministratorBoundedContextCommunications;

namespace PiensaPeru.API.Domain.Services.AdministratorBoundedContextServices
{
    public interface IAdministratorService
    {
        Task<IEnumerable<Administrator>> ListAsync();
        Task<AdministratorResponse> GetByIdAsync(int id);
        Task<AdministratorResponse> SaveAsync(Administrator administrator);
        Task<AdministratorResponse> UpdateAsync(int id, Administrator administrator);
        Task<AdministratorResponse> DeleteAsync(int id);
    }
}
