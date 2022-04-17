using PiensaPeru.API.Domain.Models.ContentBoundedContextModels;
using PiensaPeru.API.Domain.Services.Communications.ContentBoundedContextResponses;

namespace PiensaPeru.API.Domain.Services.ContentBoundedContextIServices
{
    public interface IPeriodService
    {
        Task<IEnumerable<Period>> ListAsync();
        Task<PeriodResponse> GetByIdAsync(int id);
        Task<PeriodResponse> SaveAsync(Period period);
        Task<PeriodResponse> UpdateAsync(int id, Period period);
        Task<PeriodResponse> DeleteAsync(int id);
    }
}
