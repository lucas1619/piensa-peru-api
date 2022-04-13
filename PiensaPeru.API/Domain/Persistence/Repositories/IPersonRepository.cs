using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Domain.Persistence.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> ListAsync();
        Task AddAsync(Person person);
        Task<Person> FindById(int id);
        void Update(Person person);
        void Remove(Person person);
    }
}
