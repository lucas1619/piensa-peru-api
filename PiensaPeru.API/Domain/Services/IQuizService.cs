using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Services.Communications;

namespace PiensaPeru.API.Domain.Services
{
    public interface IQuizService
    {
        Task<IEnumerable<Quiz>> ListAsync();
        Task<IEnumerable<Quiz>> ListByPostIdAsync(int postId);
        Task<QuizResponse> GetByIdAsync(int id);
        Task<QuizResponse> SaveAsync(int postId, Quiz quiz);
        Task<QuizResponse> UpdateAsync(int id, Quiz quiz);
        Task<QuizResponse> DeleteAsync(int id);
    }
}
