using Microsoft.EntityFrameworkCore;
using PiensaPeru.API.Domain.Models.ContentBoundedContextModels;
using PiensaPeru.API.Domain.Persistence.Contexts;
using PiensaPeru.API.Domain.Persistence.Repositories;

namespace PiensaPeru.API.Persistence.Repositories.ContentBoundedContextRepositories
{
    public class MilitantContentRepository : BaseRepository, IMilitantContentRepository
    {
        public MilitantContentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(MilitantContent militantContent)
        {
            await _context.MilitantContents.AddAsync(militantContent);
        }

        public async Task<IEnumerable<MilitantContent>> ListAsync()
        {
            return await _context.MilitantContents
                .Include(pt => pt.Militant)
                .Include(pt => pt.Content)
                .Include(pt => pt.Period)
                .ToListAsync();
        }

        public void Remove(MilitantContent militantContent)
        {
            _context.MilitantContents.Remove(militantContent);
        }

        public async Task<IEnumerable<MilitantContent>> ListByMilitantIdAsync(int militantId)
        {
            return await _context.MilitantContents
                .Where(pt => pt.MilitantId == militantId)
                .Include(pt => pt.Militant)
                .Include(pt => pt.Content)
                .Include(pt => pt.Period)
                .ToListAsync();
        }

        public async Task<IEnumerable<MilitantContent>> ListByContentIdAsync(int contentId)
        {
            return await _context.MilitantContents
                .Where(pt => pt.ContentId == contentId)
                .Include(pt => pt.Militant)
                .Include(pt => pt.Content)
                .Include(pt => pt.Period)
                .ToListAsync();
        }

        public async Task<MilitantContent> FindByMilitantIdAndContentId(int militantId, int contentId)
        {
            return await _context.MilitantContents.FindAsync(militantId, contentId);
        }

        public async Task AssignMilitantContent(int militantId, int contentId, int periodId)
        {
            MilitantContent militantContent = await FindByMilitantIdAndContentId(militantId, contentId);
            if (militantContent == null)
            {
                militantContent = new MilitantContent { 
                    MilitantId = militantId, 
                    ContentId = contentId,
                    PeriodId = periodId
                };
                await AddAsync(militantContent);
            }
        }

        public async void UnassignMilitantContent(int militantId, int contentId)
        {
            MilitantContent militantContent = await _context.MilitantContents.FindAsync(militantId, contentId);
            if (militantContent != null)
                Remove(militantContent);
        }
    }
}
