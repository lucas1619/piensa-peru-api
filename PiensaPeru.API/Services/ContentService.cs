using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Persistence.Repositories;
using PiensaPeru.API.Domain.Services;
using PiensaPeru.API.Domain.Services.Communications;

namespace PiensaPeru.API.Services
{
    public class ContentService
    {
        private readonly IContentRepository _contentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ContentService(IContentRepository contentRepository, IUnitOfWork unitOfWork)
        {
            _contentRepository = contentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ContentResponse> GetByIdAsync(int id)
        {
            var existingContent = await _contentRepository.FindById(id);

            if (existingContent == null)
                return new ContentResponse("Content not found");
            return new ContentResponse(existingContent);
        }

        public async Task<IEnumerable<Content>> ListAsync()
        {
            return await _contentRepository.ListAsync();
        }

        public async Task<ContentResponse> SaveAsync(Content content)
        {
            try
            {
                //content.PersonId = personId;
                await _contentRepository.AddAsync(content);
                await _unitOfWork.CompleteAsync();

                return new ContentResponse(content);
            }
            catch (Exception ex)
            {
                return new ContentResponse($"An error ocurred while saving the content: {ex.Message}");
            }
        }

        public async Task<ContentResponse> UpdateAsync(int id, Content content)
        {
            var existingContent = await _contentRepository.FindById(id);

            if (existingContent == null)
                return new ContentResponse("Content not found");

            existingContent.Active = content.Active;

            try
            {
                _contentRepository.Update(existingContent);
                await _unitOfWork.CompleteAsync();

                return new ContentResponse(existingContent);
            }
            catch (Exception ex)
            {
                return new ContentResponse($"An error ocurred while updating the content: {ex.Message}");
            }
        }

        public async Task<ContentResponse> DeleteAsync(int id)
        {
            var existingPerson = await _contentRepository.FindById(id);

            if (existingPerson == null)
                return new ContentResponse("Person not found");

            try
            {
                _contentRepository.Remove(existingPerson);
                await _unitOfWork.CompleteAsync();

                return new ContentResponse(existingPerson);
            }
            catch (Exception ex)
            {
                return new ContentResponse($"An error ocurred while deleting the person: {ex.Message}");
            }
        }
    }
}
