using Microsoft.EntityFrameworkCore;
using PiensaPeru.API.Domain.Models.ContentBoundedContextModels;
using PiensaPeru.API.Domain.Persistence.Contexts;
using PiensaPeru.API.Domain.Persistence.Repositories.ContentBoundedContextIRepositories;

namespace PiensaPeru.API.Persistence.Repositories.ContentBoundedContextRepositories
{
    public class PeriodRepository : BaseRepository, IPeriodRepository
    {
        public PeriodRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<Period> FindById(int id)
        {
            return await _context.Periods.FindAsync(id);
        }

        public async Task AddAsync(Period period)
        {
            await _context.Periods.AddAsync(period);
        }

        public async Task<IEnumerable<Period>> ListAsync()
        {
            return await _context.Periods.ToListAsync();
        }

        public void Update(Period period)
        {
            _context.Periods.Update(period);
        }

        public void Remove(Period period)
        {
            _context.Periods.Remove(period);
        }
    }
}
