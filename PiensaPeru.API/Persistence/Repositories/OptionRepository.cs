using Microsoft.EntityFrameworkCore;
using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Persistence.Contexts;
using PiensaPeru.API.Domain.Persistence.Repositories;

namespace PiensaPeru.API.Persistence.Repositories
{
    public class OptionRepository : BaseRepository, IOptionRepository
    {
        public OptionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Option option)
        {
            await _context.Options.AddAsync(option);
        }

        public async Task<Option> FindById(int id)
        {
            return await _context.Options.FindAsync(id);
        }

        public async Task<IEnumerable<Option>> ListAsync()
        {
            return await _context.Options.ToListAsync();
        }

        public async Task<IEnumerable<Option>> ListByQuestionIdAsync(int questionId)
        {
            return await _context.Options
                .Where(o => o.QuestionId == questionId)
                .Include(o => o.Question)
                .ToListAsync();
        }

        public void Remove(Option option)
        {
            _context.Options.Remove(option);
        }

        public void Update(Option option)
        {
            _context.Options.Update(option);
        }
    }
}
