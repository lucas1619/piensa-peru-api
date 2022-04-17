using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Services.Communications;
using System.Collections.Generic;

namespace PiensaPeru.API.Domain.Services
{
    public interface IImageService
    {
        Task<IEnumerable<Image>> ListAsync();
        Task<ImageResponse> GetByIdAsync(int id);
        Task<ImageResponse> SaveAsync(Image image);
        Task<ImageResponse> UpdateAsync(int id, Image image);
        Task<ImageResponse> DeleteAsync(int id);
    }
}
