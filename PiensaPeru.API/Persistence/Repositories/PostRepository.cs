using Microsoft.EntityFrameworkCore;
using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Persistence.Contexts;
using PiensaPeru.API.Domain.Persistence.Repositories;

namespace PiensaPeru.API.Persistence.Repositories
{
    public class PostRepository : BaseRepository, IPostRepository
    {
        public PostRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
        }

        public async Task<Post> FindById(int id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task<IEnumerable<Post>> ListAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<IEnumerable<Post>> ListBySupervisorIdAsync(int supervisorId)
        {
            return await _context.Posts
                .Where(p => p.SupervisorId == supervisorId)
                .ToListAsync();
        }
        
        public async Task<IEnumerable<Post>> ListPostTypesAsync()
        {
            return await _context.Posts
                .GroupBy(p => p.PostType)
                .Select(g => g.First())
                .ToListAsync();
        }

        public void Remove(Post post)
        {
            _context.Posts.Remove(post);
        }

        public void Update(Post post)
        {
            _context.Posts.Update(post);
        }
    }
}
