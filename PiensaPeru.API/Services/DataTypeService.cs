using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Persistence.Repositories;
using PiensaPeru.API.Domain.Services;
using PiensaPeru.API.Domain.Services.Communications;

namespace PiensaPeru.API.Services
{
    public class DataTypeService : IDataTypeService 
    {
        private readonly IDataTypeRepository _dataTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DataTypeService(IDataTypeRepository dataTypeRepository, IUnitOfWork unitOfWork)
        {
            _dataTypeRepository = dataTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DataTypeResponse> GetByIdAsync(int id)
        {
            var existingDataType = await _dataTypeRepository.FindById(id);

            if (existingDataType == null)
                return new DataTypeResponse("DataType not found");
            return new DataTypeResponse(existingDataType);
        }

        public async Task<IEnumerable<DataType>> ListAsync()
        {
            return await _dataTypeRepository.ListAsync();
        }

        public async Task<DataTypeResponse> SaveAsync(DataType dataType)
        {
            try
            {
                //dataType.PersonId = personId;
                await _dataTypeRepository.AddAsync(dataType);
                await _unitOfWork.CompleteAsync();

                return new DataTypeResponse(dataType);
            }
            catch (Exception ex)
            {
                return new DataTypeResponse($"An error ocurred while saving the dataType: {ex.Message}");
            }
        }

        public async Task<DataTypeResponse> UpdateAsync(int id, DataType dataType)
        {
            var existingDataType = await _dataTypeRepository.FindById(id);

            if (existingDataType == null)
                return new DataTypeResponse("DataType not found");

            existingDataType.Name = dataType.Name;

            try
            {
                _dataTypeRepository.Update(existingDataType);
                await _unitOfWork.CompleteAsync();

                return new DataTypeResponse(existingDataType);
            }
            catch (Exception ex)
            {
                return new DataTypeResponse($"An error ocurred while updating the dataType: {ex.Message}");
            }
        }

        public async Task<DataTypeResponse> DeleteAsync(int id)
        {
            var existingPerson = await _dataTypeRepository.FindById(id);

            if (existingPerson == null)
                return new DataTypeResponse("Person not found");

            try
            {
                _dataTypeRepository.Remove(existingPerson);
                await _unitOfWork.CompleteAsync();

                return new DataTypeResponse(existingPerson);
            }
            catch (Exception ex)
            {
                return new DataTypeResponse($"An error ocurred while deleting the person: {ex.Message}");
            }
        }
    }
}
