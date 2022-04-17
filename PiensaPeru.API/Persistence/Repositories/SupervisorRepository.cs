using Microsoft.EntityFrameworkCore;
using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Persistence.Contexts;
using PiensaPeru.API.Domain.Persistence.Repositories;

namespace PiensaPeru.API.Persistence.Repositories
{
    public class SupervisorRepository : BaseRepository, ISupervisorRepository
    {
        public SupervisorRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Supervisor supervisor)
        {
            await _context.Supervisors.AddAsync(supervisor);
        }

        public async Task<Supervisor> FindById(int id)
        {
            return await _context.Supervisors.FindAsync(id);
        }

        public async Task<IEnumerable<Supervisor>> ListAsync()
        {
            return await _context.Supervisors.ToListAsync();
        }

        public void Update(Supervisor supervisor)
        {
            _context.Supervisors.Update(supervisor);
        }

        public void Remove(Supervisor supervisor)
        {
            _context.Supervisors.Remove(supervisor);
        }
    }
}
