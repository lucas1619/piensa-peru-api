using Microsoft.EntityFrameworkCore;
using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Persistence.Contexts;
using PiensaPeru.API.Domain.Persistence.Repositories;

namespace PiensaPeru.API.Persistence.Repositories
{
    public class PercentageDataRepository: BaseRepository, IPercentageDataRepository
    {
        public PercentageDataRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PercentageData> FindById(int id)
        {
            return await _context.PercentagesData.FindAsync(id);
        }

        public async Task<IEnumerable<PercentageData>> ListAsync()
        {
            return await _context.PercentagesData.ToListAsync();
        }

        public async Task AddAsync(PercentageData percentageData)
        {
            await _context.PercentagesData.AddAsync(percentageData);
        }

        public void Update(PercentageData percentageData)
        {
            _context.PercentagesData.Update(percentageData);
        }

        public void Remove(PercentageData percentageData)
        {
            _context.PercentagesData.Remove(percentageData);
        }
    }
}
