using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Services.Communications;
using System.Collections.Generic;

namespace PiensaPeru.API.Domain.Services
{
    public interface IPercentageDataService
    {
        Task<IEnumerable<PercentageData>> ListAsync();
        Task<PercentageDataResponse> GetByIdAsync(int id);
        Task<PercentageDataResponse> SaveAsync(int contentId, PercentageData percentageData);
        Task<PercentageDataResponse> UpdateAsync(int id, PercentageData percentageData);
        Task<PercentageDataResponse> DeleteAsync(int id);
    }
}
