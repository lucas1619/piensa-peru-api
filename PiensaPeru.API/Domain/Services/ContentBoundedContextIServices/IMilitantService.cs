using PiensaPeru.API.Domain.Models.ContentBoundedContextModels;
using PiensaPeru.API.Domain.Services.Communications.ContentBoundedContextResponses;

namespace PiensaPeru.API.Domain.Services.ContentBoundedContextIServices
{
    public interface IMilitantService
    {
        Task<IEnumerable<Militant>> ListAsync();
        Task<MilitantResponse> GetByIdAsync(int id);
        Task<MilitantResponse> SaveAsync(Militant militant);
        Task<MilitantResponse> UpdateAsync(int id, Militant militant);
        Task<MilitantResponse> DeleteAsync(int id);
    }
}
