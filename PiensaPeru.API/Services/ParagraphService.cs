using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Persistence.Repositories;
using PiensaPeru.API.Domain.Services;
using PiensaPeru.API.Domain.Services.Communications;

namespace PiensaPeru.API.Services
{
    public class ParagraphService : IParagraphService
    {
        private readonly IParagraphRepository _paragraphRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ParagraphService(IParagraphRepository paragraphRepository, IUnitOfWork unitOfWork)
        {
            _paragraphRepository = paragraphRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ParagraphResponse> GetByIdAsync(int id)
        {
            var existingParagraph = await _paragraphRepository.FindById(id);

            if (existingParagraph == null)
                return new ParagraphResponse("Paragraph not found");
            return new ParagraphResponse(existingParagraph);
        }

        public async Task<IEnumerable<Paragraph>> ListAsync()
        {
            return await _paragraphRepository.ListAsync();
        }

        public async Task<ParagraphResponse> SaveAsync(int postId, Paragraph paragraph)
        {
            try
            {
                paragraph.PostId = postId;
                await _paragraphRepository.AddAsync(paragraph);
                await _unitOfWork.CompleteAsync();

                return new ParagraphResponse(paragraph);
            }
            catch (Exception ex)
            {
                return new ParagraphResponse($"An error ocurred while saving the paragraph: {ex.Message}");
            }
        }

        public async Task<ParagraphResponse> UpdateAsync(int id, Paragraph paragraph)
        {
            var existingParagraph = await _paragraphRepository.FindById(id);

            if (existingParagraph == null)
                return new ParagraphResponse("Paragraph not found");

            existingParagraph.Title = paragraph.Title;
            existingParagraph.Content = paragraph.Content;

            try
            {
                _paragraphRepository.Update(existingParagraph);
                await _unitOfWork.CompleteAsync();

                return new ParagraphResponse(existingParagraph);
            }
            catch (Exception ex)
            {
                return new ParagraphResponse($"An error ocurred while updating the paragraph: {ex.Message}");
            }
        }

        public async Task<ParagraphResponse> DeleteAsync(int id)
        {
            var existingPerson = await _paragraphRepository.FindById(id);

            if (existingPerson == null)
                return new ParagraphResponse("Person not found");

            try
            {
                _paragraphRepository.Remove(existingPerson);
                await _unitOfWork.CompleteAsync();

                return new ParagraphResponse(existingPerson);
            }
            catch (Exception ex)
            {
                return new ParagraphResponse($"An error ocurred while deleting the person: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Paragraph>> ListByPostIdAsync(int postId)
        {
            return await _paragraphRepository.ListByPostIdAsync(postId);
        }
    }
}
