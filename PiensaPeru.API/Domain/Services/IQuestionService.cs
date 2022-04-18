using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Services.Communications;

namespace PiensaPeru.API.Domain.Services
{
    public interface IQuestionService
    {
        Task<IEnumerable<Question>> ListAsync();
        Task<IEnumerable<Question>> ListByQuizIdAsync(int quizId);
        Task<QuestionResponse> GetByIdAsync(int id);
        Task<QuestionResponse> SaveAsync(int quizId, Question question);
        Task<QuestionResponse> UpdateAsync(int id, Question question);
        Task<QuestionResponse> DeleteAsync(int id);
    }
}
