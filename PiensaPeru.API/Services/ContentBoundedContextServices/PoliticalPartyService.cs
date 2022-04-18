using PiensaPeru.API.Domain.Models.ContentBoundedContextModels;
using PiensaPeru.API.Domain.Persistence.Repositories;
using PiensaPeru.API.Domain.Persistence.Repositories.ContentBoundedContextIRepositories;
using PiensaPeru.API.Domain.Services.Communications.ContentBoundedContextResponses;
using PiensaPeru.API.Domain.Services.ContentBoundedContextIServices;

namespace PiensaPeru.API.Services.ContentBoundedContextServices
{
    public class PoliticalPartyService : IPoliticalPartyService
    {
        private readonly IPoliticalPartyRepository _politicalPartyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PoliticalPartyService(IPoliticalPartyRepository politicalPartyRepository, IUnitOfWork unitOfWork)
        {
            _politicalPartyRepository = politicalPartyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PoliticalPartyResponse> GetByIdAsync(int id)
        {
            var existingPoliticalParty = await _politicalPartyRepository.FindById(id);

            if (existingPoliticalParty == null)
                return new PoliticalPartyResponse("PoliticalParty not found");
            return new PoliticalPartyResponse(existingPoliticalParty);
        }

        public async Task<IEnumerable<PoliticalParty>> ListAsync()
        {
            return await _politicalPartyRepository.ListAsync();
        }

        public async Task<PoliticalPartyResponse> SaveAsync(PoliticalParty politicalParty)
        {
            try
            {
                //politicalParty.PersonId = personId;
                await _politicalPartyRepository.AddAsync(politicalParty);
                await _unitOfWork.CompleteAsync();

                return new PoliticalPartyResponse(politicalParty);
            }
            catch (Exception ex)
            {
                return new PoliticalPartyResponse($"An error ocurred while saving the PoliticalParty: {ex.Message}");
            }
        }

        public async Task<PoliticalPartyResponse> UpdateAsync(int id, PoliticalParty politicalParty)
        {
            var existingPoliticalParty = await _politicalPartyRepository.FindById(id);

            if (existingPoliticalParty == null)
                return new PoliticalPartyResponse("PoliticalParty not found");

            existingPoliticalParty.Name = politicalParty.Name;
            existingPoliticalParty.PresidentName = politicalParty.PresidentName;
            existingPoliticalParty.FoundationDate = politicalParty.FoundationDate;
            existingPoliticalParty.Ideology = politicalParty.Ideology;
            existingPoliticalParty.Position = politicalParty.Position;
            existingPoliticalParty.PictureLink = politicalParty.PictureLink;

            try
            {
                _politicalPartyRepository.Update(existingPoliticalParty);
                await _unitOfWork.CompleteAsync();

                return new PoliticalPartyResponse(existingPoliticalParty);
            }
            catch (Exception ex)
            {
                return new PoliticalPartyResponse($"An error ocurred while updating the PoliticalParty: {ex.Message}");
            }
        }

        public async Task<PoliticalPartyResponse> DeleteAsync(int id)
        {
            var existingPerson = await _politicalPartyRepository.FindById(id);

            if (existingPerson == null)
                return new PoliticalPartyResponse("Person not found");

            try
            {
                _politicalPartyRepository.Remove(existingPerson);
                await _unitOfWork.CompleteAsync();

                return new PoliticalPartyResponse(existingPerson);
            }
            catch (Exception ex)
            {
                return new PoliticalPartyResponse($"An error ocurred while deleting the person: {ex.Message}");
            }
        }
    }
}
