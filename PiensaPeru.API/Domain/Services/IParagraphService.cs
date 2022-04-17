using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Services.Communications;
using System.Collections.Generic;

namespace PiensaPeru.API.Domain.Services
{
    public interface IParagraphService
    {
        Task<IEnumerable<Paragraph>> ListAsync();
        Task<ParagraphResponse> GetByIdAsync(int id);
        Task<ParagraphResponse> SaveAsync(Paragraph paragraph);
        Task<ParagraphResponse> UpdateAsync(int id, Paragraph paragraph);
        Task<ParagraphResponse> DeleteAsync(int id);
    }
}
