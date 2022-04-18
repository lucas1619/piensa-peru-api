using PiensaPeru.API.Domain.Models.ContentBoundedContextModels;
using PiensaPeru.API.Domain.Persistence.Repositories;
using PiensaPeru.API.Domain.Services.Communications.ContentBoundedContextResponses;
using PiensaPeru.API.Domain.Services.ContentBoundedContextIServices;

namespace PiensaPeru.API.Services.ContentBoundedContextServices
{
    public class MilitantContentService : IMilitantContentService
    {
        private readonly IMilitantContentRepository _militantContentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MilitantContentService(IMilitantContentRepository militantContentRepository, IUnitOfWork unitOfWork)
        {
            _militantContentRepository = militantContentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<MilitantContent>> ListAsync()
        {
            return await _militantContentRepository.ListAsync();
        }

        public async Task<IEnumerable<MilitantContent>> ListByMilitantIdAsync(int militantId)
        {
            return await _militantContentRepository.ListByMilitantIdAsync(militantId);
        }

        public async Task<IEnumerable<MilitantContent>> ListByContentIdAsync(int contentId)
        {
            return await _militantContentRepository.ListByContentIdAsync(contentId);
        }

        public async Task<MilitantContentResponse> AssignMilitantContentAsync(int militantId, int contentId, int periodId)
        {
            try
            {
                await _militantContentRepository.AssignMilitantContent(militantId, contentId, periodId);
                await _unitOfWork.CompleteAsync();

                MilitantContent militantContent = await _militantContentRepository.FindByMilitantIdAndContentId(militantId, contentId);

                return new MilitantContentResponse(militantContent);
            }
            catch (Exception ex)
            {
                return new MilitantContentResponse($"An error ocurred while assigning Militant Content to Militant: {ex.Message}");
            }
        }

        public async Task<MilitantContentResponse> UnassignMilitantContentAsync(int militantId, int contentId)
        {
            try
            {
                MilitantContent militantContent = await _militantContentRepository.FindByMilitantIdAndContentId(militantId, contentId);
                _militantContentRepository.UnassignMilitantContent(militantId, contentId);
                await _unitOfWork.CompleteAsync();

                return new MilitantContentResponse(militantContent);
            }
            catch (Exception ex)
            {
                return new MilitantContentResponse($"An error ocurred while unassigning Militant Content to Militant: {ex.Message}");
            }
        }
    }
}
