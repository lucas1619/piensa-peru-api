using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Domain.Persistence.Repositories
{
    public interface IQuizRepository
    {
        Task<IEnumerable<Quiz>> ListAsync();
        Task<IEnumerable<Quiz>> ListByPostIdAsync(int postId);
        Task<Quiz> FindById(int id);
        Task AddAsync(Quiz quiz);
        void Update(Quiz quiz);
        void Remove(Quiz quiz);
    }
}
