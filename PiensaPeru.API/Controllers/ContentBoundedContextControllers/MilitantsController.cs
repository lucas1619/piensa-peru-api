using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PiensaPeru.API.Domain.Models.ContentBoundedContextModels;
using PiensaPeru.API.Domain.Services.ContentBoundedContextIServices;
using PiensaPeru.API.Extensions;
using PiensaPeru.API.Resources.ContentBoundedContextResources;

namespace PiensaPeru.API.Controllers.ContentBoundedContextControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MilitantsController : ControllerBase
    {
        private readonly IMilitantService _militantService;
        private readonly IMapper _mapper;

        public MilitantsController(IMilitantService militantService, IMapper mapper)
        {
            _militantService = militantService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MilitantResource>), 200)]
        public async Task<IEnumerable<MilitantResource>> GetAllAsync()
        {
            var militants = await _militantService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Militant>, IEnumerable<MilitantResource>>(militants);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MilitantResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _militantService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var militantResource = _mapper.Map<Militant, MilitantResource>(result.Resource);
            return Ok(militantResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(MilitantResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveMilitantResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var militant = _mapper.Map<SaveMilitantResource, Militant>(resource);
            var result = await _militantService.SaveAsync(militant);

            if (!result.Success)
                return BadRequest(result.Message);

            var militantResource = _mapper.Map<Militant, MilitantResource>(result.Resource);
            return Ok(militantResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(MilitantResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveMilitantResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var militant = _mapper.Map<SaveMilitantResource, Militant>(resource);
            var result = await _militantService.UpdateAsync(id, militant);

            if (!result.Success)
                return BadRequest(result.Message);

            var militantResource = _mapper.Map<Militant, MilitantResource>(result.Resource);
            return Ok(militantResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(MilitantResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _militantService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var personResource = _mapper.Map<Militant, MilitantResource>(result.Resource);
            return Ok(personResource);
        }        
    }
}
