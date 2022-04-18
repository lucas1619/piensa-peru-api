using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Persistence.Repositories;
using PiensaPeru.API.Domain.Services;
using PiensaPeru.API.Domain.Services.Communications;

namespace PiensaPeru.API.Services
{
    public class PercentageDataService : IPercentageDataService
    {
        private readonly IPercentageDataRepository _percentageDataRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PercentageDataService(IPercentageDataRepository percentageDataRepository, IUnitOfWork unitOfWork)
        {
            _percentageDataRepository = percentageDataRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PercentageDataResponse> GetByIdAsync(int id)
        {
            var existingPercentageData = await _percentageDataRepository.FindById(id);

            if (existingPercentageData == null)
                return new PercentageDataResponse("PercentageData not found");
            return new PercentageDataResponse(existingPercentageData);
        }

        public async Task<IEnumerable<PercentageData>> ListAsync()
        {
            return await _percentageDataRepository.ListAsync();
        }

        public async Task<PercentageDataResponse> SaveAsync(int contentId, PercentageData percentageData)
        {
            try
            {
                percentageData.ContentId = contentId;
                await _percentageDataRepository.AddAsync(percentageData);
                await _unitOfWork.CompleteAsync();

                return new PercentageDataResponse(percentageData);
            }
            catch (Exception ex)
            {
                return new PercentageDataResponse($"An error ocurred while saving the percentageData: {ex.Message}");
            }
        }

        public async Task<PercentageDataResponse> UpdateAsync(int id, PercentageData percentageData)
        {
            var existingPercentageData = await _percentageDataRepository.FindById(id);

            if (existingPercentageData == null)
                return new PercentageDataResponse("PercentageData not found");

            existingPercentageData.Number = percentageData.Number;
            existingPercentageData.Description = percentageData.Description;

            try
            {
                _percentageDataRepository.Update(existingPercentageData);
                await _unitOfWork.CompleteAsync();

                return new PercentageDataResponse(existingPercentageData);
            }
            catch (Exception ex)
            {
                return new PercentageDataResponse($"An error ocurred while updating the percentageData: {ex.Message}");
            }
        }

        public async Task<PercentageDataResponse> DeleteAsync(int id)
        {
            var existingPerson = await _percentageDataRepository.FindById(id);

            if (existingPerson == null)
                return new PercentageDataResponse("Person not found");

            try
            {
                _percentageDataRepository.Remove(existingPerson);
                await _unitOfWork.CompleteAsync();

                return new PercentageDataResponse(existingPerson);
            }
            catch (Exception ex)
            {
                return new PercentageDataResponse($"An error ocurred while deleting the person: {ex.Message}");
            }
        }
    }
}
