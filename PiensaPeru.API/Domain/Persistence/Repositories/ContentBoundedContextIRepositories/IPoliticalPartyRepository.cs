using PiensaPeru.API.Domain.Models.ContentBoundedContextModels;

namespace PiensaPeru.API.Domain.Persistence.Repositories.ContentBoundedContextIRepositories
{
    public interface IPoliticalPartyRepository
    {
        Task<IEnumerable<PoliticalParty>> ListAsync();
        Task<PoliticalParty> FindById(int id);
        Task AddAsync(PoliticalParty politicalParty);
        void Update(PoliticalParty politicalParty);
        void Remove(PoliticalParty politicalParty);
    }
}
