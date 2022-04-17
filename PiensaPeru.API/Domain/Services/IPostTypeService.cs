using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Services.Communications;
using System.Collections.Generic;

namespace PiensaPeru.API.Domain.Services
{
    public interface IPostTypeService
    {
        Task<IEnumerable<PostType>> ListAsync();
        Task<PostTypeResponse> GetByIdAsync(int id);
        Task<PostTypeResponse> SaveAsync(PostType postType);
        Task<PostTypeResponse> UpdateAsync(int id, PostType postType);
        Task<PostTypeResponse> DeleteAsync(int id);
    }
}
