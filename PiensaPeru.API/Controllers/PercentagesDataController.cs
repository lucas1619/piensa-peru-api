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
    public class PercentagesDataController : ControllerBase
    {
        private readonly IPercentageDataService _percentageDataService;
        private readonly IMapper _mapper;

        public PercentagesDataController(IPercentageDataService percentageDataService, IMapper mapper)
        {
            _percentageDataService = percentageDataService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PercentageDataResource>), 200)]
        public async Task<IEnumerable<PercentageDataResource>> GetAllAsync()
        {
            var percentageDatas = await _percentageDataService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<PercentageData>, IEnumerable<PercentageDataResource>>(percentageDatas);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PercentageDataResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _percentageDataService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var percentageDataResource = _mapper.Map<PercentageData, PercentageDataResource>(result.Resource);
            return Ok(percentageDataResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PercentageDataResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync(int contentId, [FromBody] SavePercentageDataResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var percentageData = _mapper.Map<SavePercentageDataResource, PercentageData>(resource);
            var result = await _percentageDataService.SaveAsync(contentId, percentageData);

            if (!result.Success)
                return BadRequest(result.Message);

            var percentageDataResource = _mapper.Map<PercentageData, PercentageDataResource>(result.Resource);
            return Ok(percentageDataResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PercentageDataResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePercentageDataResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var percentageData = _mapper.Map<SavePercentageDataResource, PercentageData>(resource);
            var result = await _percentageDataService.UpdateAsync(id, percentageData);

            if (!result.Success)
                return BadRequest(result.Message);

            var percentageDataResource = _mapper.Map<PercentageData, PercentageDataResource>(result.Resource);
            return Ok(percentageDataResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PercentageDataResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _percentageDataService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var personResource = _mapper.Map<PercentageData, PercentageDataResource>(result.Resource);
            return Ok(personResource);
        }
    }
}
