using Microsoft.EntityFrameworkCore;
using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Persistence.Contexts;
using PiensaPeru.API.Domain.Persistence.Repositories;

namespace PiensaPeru.API.Persistence.Repositories
{
    public class PostTypeRepository : BaseRepository, IPostTypeRepository
    {
        public PostTypeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PostType> FindById(int id)
        {
            return await _context.PostTypes.FindAsync(id);
        }

        public async Task<IEnumerable<PostType>> ListAsync()
        {
            return await _context.PostTypes.ToListAsync();
        }

        public async Task AddAsync(PostType postType)
        {
            await _context.PostTypes.AddAsync(postType);
        }

        public void Update(PostType postType)
        {
            _context.PostTypes.Update(postType);
        }

        public void Remove(PostType postType)
        {
            _context.PostTypes.Remove(postType);
        }
    }
}
