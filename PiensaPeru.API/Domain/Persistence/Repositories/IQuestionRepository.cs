using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Domain.Persistence.Repositories
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> ListAsync();
        Task<Question> FindById(int id);
        Task AddAsync(Question question);
        void Update(Question question);
        void Remove(Question question);
    }
}
