using PiensaPeru.API.Domain.Models.AdministratorBoundedContextModels;
using PiensaPeru.API.Domain.Services.Communications.AdministratorBoundedContextCommunications;

namespace PiensaPeru.API.Domain.Services.AdministratorBoundedContextServices
{
    public interface IManagementService
    {
        Task<IEnumerable<Management>> ListAsync();
        Task<IEnumerable<Management>> ListByAdministratorIdAsync(int administratorId);
        Task<ManagementResponse> GetByIdAsync(int id);
        Task<ManagementResponse> SaveAsync(int administratorId, int contentId, Management management);
        Task<ManagementResponse> UpdateAsync(int id, Management management);
        Task<ManagementResponse> DeleteAsync(int id);
    }
}
