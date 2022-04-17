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
    public class OptionsController : ControllerBase
    {
        private readonly IOptionService _optionService;
        private readonly IMapper _mapper;

        public OptionsController(IOptionService optionService, IMapper mapper)
        {
            _optionService = optionService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OptionResource>), 200)]
        public async Task<IEnumerable<OptionResource>> GetAllAsync()
        {
            var options = await _optionService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Option>, IEnumerable<OptionResource>>(options);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OptionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _optionService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var optionResource = _mapper.Map<Option, OptionResource>(result.Resource);
            return Ok(optionResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(OptionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveOptionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var option = _mapper.Map<SaveOptionResource, Option>(resource);
            var result = await _optionService.SaveAsync(option);

            if (!result.Success)
                return BadRequest(result.Message);

            var optionResource = _mapper.Map<Option, OptionResource>(result.Resource);
            return Ok(optionResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(OptionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveOptionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var option = _mapper.Map<SaveOptionResource, Option>(resource);
            var result = await _optionService.UpdateAsync(id, option);

            if (!result.Success)
                return BadRequest(result.Message);

            var optionResource = _mapper.Map<Option, OptionResource>(result.Resource);
            return Ok(optionResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(OptionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _optionService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var personResource = _mapper.Map<Option, OptionResource>(result.Resource);
            return Ok(personResource);
        }
    }
}
