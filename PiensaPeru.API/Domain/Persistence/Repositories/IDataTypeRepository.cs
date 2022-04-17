using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Domain.Persistence.Repositories
{
    public interface IDataTypeRepository
    {
        Task<IEnumerable<DataType>> ListAsync();
        Task<DataType> FindById(int id);
        Task AddAsync(DataType dataType);
        void Update(DataType dataType);
        void Remove(DataType dataType);
    }
}
