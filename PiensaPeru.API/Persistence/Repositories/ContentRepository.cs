using Microsoft.EntityFrameworkCore;
using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Persistence.Contexts;
using PiensaPeru.API.Domain.Persistence.Repositories;

namespace PiensaPeru.API.Persistence.Repositories
{
    public class ContentRepository : BaseRepository, IContentRepository
    {
        public ContentRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<Content> FindById(int id)
        {
            return await _context.Contents.FindAsync(id);
        }

        public async Task AddAsync(Content content)
        {
            await _context.Contents.AddAsync(content);
        }

        public async Task<IEnumerable<Content>> ListAsync()
        {
            return await _context.Contents.ToListAsync();
        }

        public void Update(Content content)
        {
            _context.Contents.Update(content);
        }
        
        public void Remove(Content content)
        {
            _context.Contents.Remove(content);
        }        
    }
}
