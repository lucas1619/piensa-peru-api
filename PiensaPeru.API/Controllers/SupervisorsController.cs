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
    public class SupervisorsController : ControllerBase
    {
        private readonly ISupervisorService _supervisorService;
        private readonly IMapper _mapper;

        public SupervisorsController(ISupervisorService supervisorService, IMapper mapper)
        {
            _supervisorService = supervisorService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SupervisorResource>), 200)]
        public async Task<IEnumerable<SupervisorResource>> GetAllAsync()
        {
            var supervisors = await _supervisorService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Supervisor>, IEnumerable<SupervisorResource>>(supervisors);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SupervisorResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _supervisorService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var supervisorResource = _mapper.Map<Supervisor, SupervisorResource>(result.Resource);
            return Ok(supervisorResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(SupervisorResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync(int personId, [FromBody] SaveSupervisorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var supervisor = _mapper.Map<SaveSupervisorResource, Supervisor>(resource);
            var result = await _supervisorService.SaveAsync(personId, supervisor);

            if (!result.Success)
                return BadRequest(result.Message);

            var supervisorResource = _mapper.Map<Supervisor, SupervisorResource>(result.Resource);
            return Ok(supervisorResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(SupervisorResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSupervisorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var supervisor = _mapper.Map<SaveSupervisorResource, Supervisor>(resource);
            var result = await _supervisorService.UpdateAsync(id, supervisor);

            if (!result.Success)
                return BadRequest(result.Message);

            var supervisorResource = _mapper.Map<Supervisor, SupervisorResource>(result.Resource);
            return Ok(supervisorResource);
        }
    }
}
