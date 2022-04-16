using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Services;
using PiensaPeru.API.Extensions;
using PiensaPeru.API.Resources;

namespace PiensaPeru.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataTypesController : ControllerBase
    {
        private readonly IDataTypeService _dataTypeService;
        private readonly IMapper _mapper;

        public DataTypesController(IDataTypeService dataTypeService, IMapper mapper)
        {
            _dataTypeService = dataTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DataTypeResource>), 200)]
        public async Task<IEnumerable<DataTypeResource>> GetAllAsync()
        {
            var dataTypes = await _dataTypeService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<DataType>, IEnumerable<DataTypeResource>>(dataTypes);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DataTypeResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _dataTypeService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var dataTypeResource = _mapper.Map<DataType, DataTypeResource>(result.Resource);
            return Ok(dataTypeResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(DataTypeResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveDataTypeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var dataType = _mapper.Map<SaveDataTypeResource, DataType>(resource);
            var result = await _dataTypeService.SaveAsync(dataType);

            if (!result.Success)
                return BadRequest(result.Message);

            var dataTypeResource = _mapper.Map<DataType, DataTypeResource>(result.Resource);
            return Ok(dataTypeResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(DataTypeResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDataTypeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var dataType = _mapper.Map<SaveDataTypeResource, DataType>(resource);
            var result = await _dataTypeService.UpdateAsync(id, dataType);

            if (!result.Success)
                return BadRequest(result.Message);

            var dataTypeResource = _mapper.Map<DataType, DataTypeResource>(result.Resource);
            return Ok(dataTypeResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PersonResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _dataTypeService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var personResource = _mapper.Map<DataType, DataTypeResource>(result.Resource);
            return Ok(personResource);
        }
    }
}
