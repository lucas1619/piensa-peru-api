using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Persistence.Repositories;
using PiensaPeru.API.Domain.Services;
using PiensaPeru.API.Domain.Services.Communications;

namespace PiensaPeru.API.Services
{
    public class OptionService : IOptionService
    {
        private readonly IOptionRepository _optionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OptionService(IOptionRepository optionRepository, IUnitOfWork unitOfWork)
        {
            _optionRepository = optionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<OptionResponse> GetByIdAsync(int id)
        {
            var existingOption = await _optionRepository.FindById(id);

            if (existingOption == null)
                return new OptionResponse("Option not found");
            return new OptionResponse(existingOption);
        }

        public async Task<IEnumerable<Option>> ListAsync()
        {
            return await _optionRepository.ListAsync();
        }

        public async Task<OptionResponse> SaveAsync(int questionId, Option option)
        {
            try
            {
                option.QuestionId = questionId;
                await _optionRepository.AddAsync(option);
                await _unitOfWork.CompleteAsync();

                return new OptionResponse(option);
            }
            catch (Exception ex)
            {
                return new OptionResponse($"An error ocurred while saving the option: {ex.Message}");
            }
        }

        public async Task<OptionResponse> UpdateAsync(int id, Option option)
        {
            var existingOption = await _optionRepository.FindById(id);

            if (existingOption == null)
                return new OptionResponse("Option not found");

            existingOption.Description = option.Description;
            existingOption.IsAnswer = option.IsAnswer;

            try
            {
                _optionRepository.Update(existingOption);
                await _unitOfWork.CompleteAsync();

                return new OptionResponse(existingOption);
            }
            catch (Exception ex)
            {
                return new OptionResponse($"An error ocurred while updating the option: {ex.Message}");
            }
        }

        public async Task<OptionResponse> DeleteAsync(int id)
        {
            var existingPerson = await _optionRepository.FindById(id);

            if (existingPerson == null)
                return new OptionResponse("Person not found");

            try
            {
                _optionRepository.Remove(existingPerson);
                await _unitOfWork.CompleteAsync();

                return new OptionResponse(existingPerson);
            }
            catch (Exception ex)
            {
                return new OptionResponse($"An error ocurred while deleting the person: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Option>> ListByQuestionIdAsync(int questionId)
        {
            return await _optionRepository.ListByQuestionIdAsync(questionId);
        }
    }
}
