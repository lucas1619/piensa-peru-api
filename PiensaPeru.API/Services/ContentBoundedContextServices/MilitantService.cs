using PiensaPeru.API.Domain.Models.ContentBoundedContextModels;
using PiensaPeru.API.Domain.Persistence.Repositories;
using PiensaPeru.API.Domain.Persistence.Repositories.ContentBoundedContextIRepositories;
using PiensaPeru.API.Domain.Services.Communications.ContentBoundedContextResponses;
using PiensaPeru.API.Domain.Services.ContentBoundedContextIServices;

namespace PiensaPeru.API.Services.ContentBoundedContextServices
{
    public class MilitantService : IMilitantService
    {
        private readonly IMilitantRepository _militantRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MilitantService(IMilitantRepository militantRepository, IUnitOfWork unitOfWork)
        {
            _militantRepository = militantRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<MilitantResponse> GetByIdAsync(int id)
        {
            var existingMilitant = await _militantRepository.FindById(id);

            if (existingMilitant == null)
                return new MilitantResponse("Militant not found");
            return new MilitantResponse(existingMilitant);
        }

        public async Task<IEnumerable<Militant>> ListAsync()
        {
            return await _militantRepository.ListAsync();
        }

        public async Task<MilitantResponse> SaveAsync(Militant militant)
        {
            try
            {
                //militant.PersonId = personId;
                await _militantRepository.AddAsync(militant);
                await _unitOfWork.CompleteAsync();

                return new MilitantResponse(militant);
            }
            catch (Exception ex)
            {
                return new MilitantResponse($"An error ocurred while saving the militant: {ex.Message}");
            }
        }

        public async Task<MilitantResponse> UpdateAsync(int id, Militant militant)
        {
            var existingMilitant = await _militantRepository.FindById(id);

            if (existingMilitant == null)
                return new MilitantResponse("Militant not found");

            existingMilitant.BirthDate = militant.BirthDate;
            existingMilitant.BirthPlace = militant.BirthPlace;
            existingMilitant.Profession = militant.Profession;
            existingMilitant.PolitcalPartyId = militant.PolitcalPartyId;
            existingMilitant.PictureLink = militant.PictureLink;
            existingMilitant.IsPresident = militant.IsPresident;
            existingMilitant.MilitantTypeId = militant.MilitantTypeId;
            existingMilitant.FirstName = militant.FirstName;
            existingMilitant.LastName = militant.LastName;

            try
            {
                _militantRepository.Update(existingMilitant);
                await _unitOfWork.CompleteAsync();

                return new MilitantResponse(existingMilitant);
            }
            catch (Exception ex)
            {
                return new MilitantResponse($"An error ocurred while updating the militant: {ex.Message}");
            }
        }

        public async Task<MilitantResponse> DeleteAsync(int id)
        {
            var existingPerson = await _militantRepository.FindById(id);

            if (existingPerson == null)
                return new MilitantResponse("Person not found");

            try
            {
                _militantRepository.Remove(existingPerson);
                await _unitOfWork.CompleteAsync();

                return new MilitantResponse(existingPerson);
            }
            catch (Exception ex)
            {
                return new MilitantResponse($"An error ocurred while deleting the person: {ex.Message}");
            }
        }
    }
}
