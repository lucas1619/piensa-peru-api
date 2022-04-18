using Microsoft.EntityFrameworkCore;
using PiensaPeru.API.Domain.Models.AdministratorBoundedContextModels;
using PiensaPeru.API.Domain.Persistence.Contexts;
using PiensaPeru.API.Domain.Persistence.Repositories.AdministratorBoundedContextRespositories;

namespace PiensaPeru.API.Persistence.Repositories.AdministratorBoundedContextRepositories
{
    public class AdministratorRepository : BaseRepository, IAdministratorRepository
    {
        public AdministratorRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Administrator administrator)
        {
            await _context.Administrators.AddAsync(administrator);
        }

        public async Task<Administrator> FindById(int id)
        {
            return await _context.Administrators.FindAsync(id);
        }

        public async Task<IEnumerable<Administrator>> ListAsync()
        {
            return await _context.Administrators.ToListAsync();
        }

        public void Remove(Administrator administrator)
        {
            _context.Administrators.Remove(administrator);
        }

        public void Update(Administrator administrator)
        {
            _context.Administrators.Update(administrator);
        }
    }
}
