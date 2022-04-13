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
    [Produces("application/json")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PeopleController(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PersonResource>), 200)]
        public async Task<IEnumerable<PersonResource>> GetAllAsync()
        {
            var people = await _personService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Person>, IEnumerable<PersonResource>>(people);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PersonResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _personService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var personResource = _mapper.Map<Person, PersonResource>(result.Resource);
            return Ok(personResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PersonResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SavePersonResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var person = _mapper.Map<SavePersonResource, Person>(resource);
            var result = await _personService.SaveAsync(person);

            if (!result.Success)
                return BadRequest(result.Message);

            var personResource = _mapper.Map<Person, PersonResource>(result.Resource);
            return Ok(personResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PersonResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePersonResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var person = _mapper.Map<SavePersonResource, Person>(resource);
            var result = await _personService.UpdateAsync(id, person);

            if (!result.Success)
                return BadRequest(result.Message);

            var personResource = _mapper.Map<Person, PersonResource>(result.Resource);
            return Ok(personResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PersonResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _personService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var personResource = _mapper.Map<Person, PersonResource>(result.Resource);
            return Ok(personResource);
        }
    }
}
