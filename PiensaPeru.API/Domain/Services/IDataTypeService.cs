using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Services.Communications;
using System.Collections.Generic;
namespace PiensaPeru.API.Domain.Services
{
    public interface IDataTypeService
    {
        Task<IEnumerable<DataType>> ListAsync();
        Task<DataTypeResponse> GetByIdAsync(int id);
        Task<DataTypeResponse> SaveAsync(DataType dataType);
        Task<DataTypeResponse> UpdateAsync(int id, DataType dataType);
        Task<DataTypeResponse> DeleteAsync(int id);
    }
}
