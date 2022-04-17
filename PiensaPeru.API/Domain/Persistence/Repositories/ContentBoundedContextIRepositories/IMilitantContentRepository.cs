using PiensaPeru.API.Domain.Models.ContentBoundedContextModels;

namespace PiensaPeru.API.Domain.Persistence.Repositories
{
    public interface IMilitantContentRepository
    {
        Task<IEnumerable<MilitantContent>> ListAsync();
        Task<IEnumerable<MilitantContent>> ListByMilitantIdAsync(int militantId);
        Task<IEnumerable<MilitantContent>> ListByContentIdAsync(int contentId);
        Task<MilitantContent> FindByMilitantIdAndContentId(int militantId, int contentId);
        Task AddAsync(MilitantContent militantContent);
        void Remove(MilitantContent militantContent);
        Task AssignMilitantContent(int militantId, int contentId, int periodId);
        void UnassignMilitantContent(int militantId, int contentId);
    }
}
