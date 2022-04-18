using Microsoft.EntityFrameworkCore;
using PiensaPeru.API.Domain.Models.ContentBoundedContextModels;
using PiensaPeru.API.Domain.Persistence.Contexts;
using PiensaPeru.API.Domain.Persistence.Repositories.ContentBoundedContextIRepositories;

namespace PiensaPeru.API.Persistence.Repositories.ContentBoundedContextRepositories
{
    public class MilitantRepository : BaseRepository, IMilitantRepository
    {
        public MilitantRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<Militant> FindById(int id)
        {
            return await _context.Militants.FindAsync(id);
        }

        public async Task AddAsync(Militant militant)
        {
            await _context.Militants.AddAsync(militant);
        }

        public async Task<IEnumerable<Militant>> ListAsync()
        {
            return await _context.Militants.ToListAsync();
        }

        public void Update(Militant militant)
        {
            _context.Militants.Update(militant);
        }

        public void Remove(Militant militant)
        {
            _context.Militants.Remove(militant);
        }
    }
}
