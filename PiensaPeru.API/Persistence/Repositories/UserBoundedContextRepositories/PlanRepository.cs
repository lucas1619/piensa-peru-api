using Microsoft.EntityFrameworkCore;
using PiensaPeru.API.Domain.Models.UserBoundedContextModels;
using PiensaPeru.API.Domain.Persistence.Contexts;
using PiensaPeru.API.Domain.Persistence.Repositories.UserBoundedContextRepositories;

namespace PiensaPeru.API.Persistence.Repositories.UserBoundedContextRepositories
{
    public class PlanRepository : BaseRepository, IPlanRepository
    {
        public PlanRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Plan plan)
        {
            await _context.Plans.AddAsync(plan);
        }

        public async Task<Plan> FindById(int id)
        {
            return await _context.Plans.FindAsync(id);
        }

        public async Task<IEnumerable<Plan>> ListAsync()
        {
            return await _context.Plans.ToListAsync();
        }

        public void Remove(Plan plan)
        {
            _context.Plans.Remove(plan);
        }

        public void Update(Plan plan)
        {
            _context.Plans.Update(plan);
        }
    }
}
