using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Services.Communications;

namespace PiensaPeru.API.Domain.Services
{
    public interface IQuestionService
    {
        Task<IEnumerable<Question>> ListAsync();
        Task<QuestionResponse> GetByIdAsync(int id);
        Task<QuestionResponse> SaveAsync(Question question);
        Task<QuestionResponse> UpdateAsync(int id, Question question);
        Task<QuestionResponse> DeleteAsync(int id);
    }
}
