using PiensaPeru.API.Domain.Models.UserBoundedContextModels;
using PiensaPeru.API.Domain.Services.Communications.UserBoundedContextCommunications;

namespace PiensaPeru.API.Domain.Services.UserBoundedContextServices
{
    public interface IPlanService
    {
        Task<IEnumerable<Plan>> ListAsync();
        Task<PlanResponse> GetByIdAsync(int id);
        Task<PlanResponse> SaveAsync(Plan plan);
        Task<PlanResponse> UpdateAsync(int id, Plan plan);
        Task<PlanResponse> DeleteAsync(int id);
    }
}
