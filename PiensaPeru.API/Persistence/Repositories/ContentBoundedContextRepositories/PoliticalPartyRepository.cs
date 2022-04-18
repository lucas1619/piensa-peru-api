using Microsoft.EntityFrameworkCore;
using PiensaPeru.API.Domain.Models.ContentBoundedContextModels;
using PiensaPeru.API.Domain.Persistence.Contexts;
using PiensaPeru.API.Domain.Persistence.Repositories.ContentBoundedContextIRepositories;

namespace PiensaPeru.API.Persistence.Repositories.ContentBoundedContextRepositories
{
    public class PoliticalPartyRepository : BaseRepository, IPoliticalPartyRepository
    {
        public PoliticalPartyRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<PoliticalParty> FindById(int id)
        {
            return await _context.PoliticalParties.FindAsync(id);
        }

        public async Task AddAsync(PoliticalParty politicalParty)
        {
            await _context.PoliticalParties.AddAsync(politicalParty);
        }

        public async Task<IEnumerable<PoliticalParty>> ListAsync()
        {
            return await _context.PoliticalParties.ToListAsync();
        }

        public void Update(PoliticalParty politicalParty)
        {
            _context.PoliticalParties.Update(politicalParty);
        }

        public void Remove(PoliticalParty politicalParty)
        {
            _context.PoliticalParties.Remove(politicalParty);
        }        
    }
}
