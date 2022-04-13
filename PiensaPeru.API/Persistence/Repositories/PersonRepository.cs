using Microsoft.EntityFrameworkCore;
using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Persistence.Contexts;
using PiensaPeru.API.Domain.Persistence.Repositories;

namespace PiensaPeru.API.Persistence.Repositories
{
    public class PersonRepository : BaseRepository, IPersonRepository
    {
        public PersonRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Person person)
        {
            await _context.People.AddAsync(person);
        }

        public async Task<Person> FindById(int id)
        {
            return await _context.People.FindAsync(id);
        }

        public async Task<IEnumerable<Person>> ListAsync()
        {
            return await _context.People.ToListAsync();
        }

        public void Remove(Person person)
        {
            _context.People.Remove(person);
        }

        public void Update(Person person)
        {
            _context.People.Update(person);
        }
    }
}
