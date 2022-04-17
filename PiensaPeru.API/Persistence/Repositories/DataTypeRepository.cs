using Microsoft.EntityFrameworkCore;
using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Persistence.Contexts;
using PiensaPeru.API.Domain.Persistence.Repositories;

namespace PiensaPeru.API.Persistence.Repositories
{
    public class DataTypeRepository : BaseRepository, IDataTypeRepository
    {
        public DataTypeRepository(AppDbContext context) : base(context)
        {
        }
        public async Task AddAsync(DataType dataType)
        {
            await _context.DataTypes.AddAsync(dataType);
        }
        
        public async Task<DataType> FindById(int id)
        {
            return await _context.DataTypes.FindAsync(id);
        }

        public async Task<IEnumerable<DataType>> ListAsync()
        {
            return await _context.DataTypes.ToListAsync();
        }

        public void Update(DataType dataType)
        {
            _context.DataTypes.Update(dataType);
        }

        public void Remove(DataType dataType)
        {
            _context.DataTypes.Remove(dataType);
        }
    }
    
}
