using PiensaPeru.API.Domain.Models.ContentBoundedContextModels;
using PiensaPeru.API.Domain.Persistence.Repositories;
using PiensaPeru.API.Domain.Persistence.Repositories.ContentBoundedContextIRepositories;
using PiensaPeru.API.Domain.Services.Communications.ContentBoundedContextResponses;
using PiensaPeru.API.Domain.Services.ContentBoundedContextIServices;

namespace PiensaPeru.API.Services.ContentBoundedContextServices
{
    public class PeriodService : IPeriodService
    {
        private readonly IPeriodRepository _periodRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PeriodService(IPeriodRepository periodRepository, IUnitOfWork unitOfWork)
        {
            _periodRepository = periodRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PeriodResponse> GetByIdAsync(int id)
        {
            var existingPeriod = await _periodRepository.FindById(id);

            if (existingPeriod == null)
                return new PeriodResponse("Period not found");
            return new PeriodResponse(existingPeriod);
        }

        public async Task<IEnumerable<Period>> ListAsync()
        {
            return await _periodRepository.ListAsync();
        }

        public async Task<PeriodResponse> SaveAsync(Period period)
        {
            try
            {
                //period.PersonId = personId;
                await _periodRepository.AddAsync(period);
                await _unitOfWork.CompleteAsync();

                return new PeriodResponse(period);
            }
            catch (Exception ex)
            {
                return new PeriodResponse($"An error ocurred while saving the period: {ex.Message}");
            }
        }

        public async Task<PeriodResponse> UpdateAsync(int id, Period period)
        {
            var existingPeriod = await _periodRepository.FindById(id);

            if (existingPeriod == null)
                return new PeriodResponse("Period not found");

            existingPeriod.StartDate = period.StartDate;
            existingPeriod.EndDate = period.EndDate;
            existingPeriod.OriginOfCharge = period.OriginOfCharge;

            try
            {
                _periodRepository.Update(existingPeriod);
                await _unitOfWork.CompleteAsync();

                return new PeriodResponse(existingPeriod);
            }
            catch (Exception ex)
            {
                return new PeriodResponse($"An error ocurred while updating the period: {ex.Message}");
            }
        }

        public async Task<PeriodResponse> DeleteAsync(int id)
        {
            var existingPerson = await _periodRepository.FindById(id);

            if (existingPerson == null)
                return new PeriodResponse("Person not found");

            try
            {
                _periodRepository.Remove(existingPerson);
                await _unitOfWork.CompleteAsync();

                return new PeriodResponse(existingPerson);
            }
            catch (Exception ex)
            {
                return new PeriodResponse($"An error ocurred while deleting the person: {ex.Message}");
            }
        }
    }
}
