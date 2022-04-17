using PiensaPeru.API.Domain.Models.ContentBoundedContextModels;
using PiensaPeru.API.Domain.Services.Communications.ContentBoundedContextResponses;

namespace PiensaPeru.API.Domain.Services.ContentBoundedContextIServices
{
    public interface IPoliticalPartyService
    {
        Task<IEnumerable<PoliticalParty>> ListAsync();
        Task<PoliticalPartyResponse> GetByIdAsync(int id);
        Task<PoliticalPartyResponse> SaveAsync(PoliticalParty politicalParty);
        Task<PoliticalPartyResponse> UpdateAsync(int id, PoliticalParty politicalParty);
        Task<PoliticalPartyResponse> DeleteAsync(int id);
    }
}
