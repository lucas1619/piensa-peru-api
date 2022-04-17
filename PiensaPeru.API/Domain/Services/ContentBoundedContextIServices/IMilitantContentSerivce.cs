using PiensaPeru.API.Domain.Models.ContentBoundedContextModels;
using PiensaPeru.API.Domain.Services.Communications.ContentBoundedContextResponses;

namespace PiensaPeru.API.Domain.Services.ContentBoundedContextIServices
{
    public interface IMilitantContentService
    {
        Task<IEnumerable<MilitantContent>> ListAsync();
        Task<IEnumerable<MilitantContent>> ListByMilitantIdAsync(int militantId);
        Task<IEnumerable<MilitantContent>> ListByContentIdAsync(int contentId);
        Task<MilitantContentResponse> AssignMilitantContentAsync(int militantId, int contentId, int periodId);
        Task<MilitantContentResponse> UnassignMilitantContentAsync(int militantId, int contentId);
    }
}
