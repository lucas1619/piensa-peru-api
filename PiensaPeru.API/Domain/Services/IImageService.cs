using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Services.Communications;
using System.Collections.Generic;

namespace PiensaPeru.API.Domain.Services
{
    public interface IImageService
    {
        Task<IEnumerable<Image>> ListAsync();
        Task<IEnumerable<Image>> ListByPostIdAsync(int postId);
        Task<ImageResponse> GetByIdAsync(int id);
        Task<ImageResponse> SaveAsync(int postId, Image image);
        Task<ImageResponse> UpdateAsync(int id, Image image);
        Task<ImageResponse> DeleteAsync(int id);
    }
}
