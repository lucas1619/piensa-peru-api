using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Services.Communications;

namespace PiensaPeru.API.Domain.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> ListAsync();
        Task<PersonResponse> GetByIdAsync(int id);
        Task<PersonResponse> SaveAsync(Person person);
        Task<PersonResponse> UpdateAsync(int id, Person person);
        Task<PersonResponse> DeleteAsync(int id);
    }
}
