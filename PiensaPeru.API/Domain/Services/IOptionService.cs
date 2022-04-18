using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Services.Communications;

namespace PiensaPeru.API.Domain.Services
{
    public interface IOptionService
    {
        Task<IEnumerable<Option>> ListAsync();
        Task<IEnumerable<Option>> ListByQuestionIdAsync(int questionId);
        Task<OptionResponse> GetByIdAsync(int id);
        Task<OptionResponse> SaveAsync(int questionId, Option supervisor);
        Task<OptionResponse> UpdateAsync(int id, Option supervisor);
        Task<OptionResponse> DeleteAsync(int id);
    }
}
