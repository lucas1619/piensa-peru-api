using Microsoft.EntityFrameworkCore;
using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Persistence.Contexts;
using PiensaPeru.API.Domain.Persistence.Repositories;

namespace PiensaPeru.API.Persistence.Repositories
{
    public class ParagraphRepository : BaseRepository, IParagraphRepository
    {
        public ParagraphRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Paragraph> FindById(int id)
        {
            return await _context.Paragraphs.FindAsync(id);
        }

        public async Task<IEnumerable<Paragraph>> ListAsync()
        {
            return await _context.Paragraphs.ToListAsync();
        }

        public async Task AddAsync(Paragraph paragraph)
        {
            await _context.Paragraphs.AddAsync(paragraph);
        }

        public void Update(Paragraph paragraph)
        {
            _context.Paragraphs.Update(paragraph);
        }

        public void Remove(Paragraph paragraph)
        {
            _context.Paragraphs.Remove(paragraph);
        }

        public async Task<IEnumerable<Paragraph>> ListByPostIdAsync(int postId)
        {
            return await _context.Paragraphs
                .Where(p => p.PostId == postId)
                .Include(p => p.Post)
                .ToListAsync();
        }
    }
}
