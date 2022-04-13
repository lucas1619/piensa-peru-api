using PiensaPeru.API.Domain.Persistence.Contexts;

namespace PiensaPeru.API.Persistence.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
