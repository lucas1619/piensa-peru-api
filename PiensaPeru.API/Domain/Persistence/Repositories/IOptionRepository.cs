using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Domain.Persistence.Repositories
{
    public interface IOptionRepository
    {
        Task<IEnumerable<Option>> ListAsync();
        Task<IEnumerable<Option>> ListByQuestionIdAsync(int questionId);
        Task<Option> FindById(int id);
        Task AddAsync(Option option);
        void Update(Option option);
        void Remove(Option option);
    }
}
