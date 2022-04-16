using Microsoft.EntityFrameworkCore;
using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Persistence.Contexts;
using PiensaPeru.API.Domain.Persistence.Repositories;

namespace PiensaPeru.API.Persistence.Repositories
{
    public class ImageRepository : BaseRepository, IImageRepository
    {
        public ImageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Image> FindById(int id)
        {
            return await _context.Images.FindAsync(id);
        }

        public async Task AddAsync(Image image)
        {
            await _context.Images.AddAsync(image);
        }

        public async Task<IEnumerable<Image>> ListAsync()
        {
            return await _context.Images.ToListAsync();
        }

        public void Update(Image image)
        {
            _context.Images.Update(image);
        }

        public void Remove(Image image)
        {
            _context.Images.Remove(image);
        }
    }
}
