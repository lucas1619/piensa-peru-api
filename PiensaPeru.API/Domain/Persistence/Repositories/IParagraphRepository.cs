using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Domain.Persistence.Repositories
{
    public interface IParagraphRepository
    {
        Task<IEnumerable<Paragraph>> ListAsync();
        Task<IEnumerable<Paragraph>> ListByPostIdAsync(int postId);
        Task<Paragraph> FindById(int id);
        Task AddAsync(Paragraph paragraph);
        void Update(Paragraph paragraph);
        void Remove(Paragraph paragraph);
    }
}
