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
    public class PoliticalPartiesController : ControllerBase
    {
        private readonly IPoliticalPartyService _politicalPartyService;
        private readonly IMapper _mapper;

        public PoliticalPartiesController(IPoliticalPartyService politicalPartyService, IMapper mapper)
        {
            _politicalPartyService = politicalPartyService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PoliticalPartyResource>), 200)]
        public async Task<IEnumerable<PoliticalPartyResource>> GetAllAsync()
        {
            var politicalParties = await _politicalPartyService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<PoliticalParty>, IEnumerable<PoliticalPartyResource>>(politicalParties);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PoliticalPartyResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _politicalPartyService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var politicalPartyResource = _mapper.Map<PoliticalParty, PoliticalPartyResource>(result.Resource);
            return Ok(politicalPartyResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PoliticalPartyResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SavePoliticalPartyResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var politicalParty = _mapper.Map<SavePoliticalPartyResource, PoliticalParty>(resource);
            var result = await _politicalPartyService.SaveAsync(politicalParty);

            if (!result.Success)
                return BadRequest(result.Message);

            var politicalPartyResource = _mapper.Map<PoliticalParty, PoliticalPartyResource>(result.Resource);
            return Ok(politicalPartyResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PoliticalPartyResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePoliticalPartyResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var politicalParty = _mapper.Map<SavePoliticalPartyResource, PoliticalParty>(resource);
            var result = await _politicalPartyService.UpdateAsync(id, politicalParty);

            if (!result.Success)
                return BadRequest(result.Message);

            var politicalPartyResource = _mapper.Map<PoliticalParty, PoliticalPartyResource>(result.Resource);
            return Ok(politicalPartyResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PoliticalPartyResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _politicalPartyService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var personResource = _mapper.Map<PoliticalParty, PoliticalPartyResource>(result.Resource);
            return Ok(personResource);
        }
    }
}
