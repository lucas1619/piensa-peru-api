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
    public class PeriodsController : ControllerBase
    {
        private readonly IPeriodService _periodService;
        private readonly IMapper _mapper;

        public PeriodsController(IPeriodService periodService, IMapper mapper)
        {
            _periodService = periodService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PeriodResource>), 200)]
        public async Task<IEnumerable<PeriodResource>> GetAllAsync()
        {
            var periods = await _periodService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Period>, IEnumerable<PeriodResource>>(periods);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PeriodResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _periodService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var periodResource = _mapper.Map<Period, PeriodResource>(result.Resource);
            return Ok(periodResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PeriodResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SavePeriodResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var period = _mapper.Map<SavePeriodResource, Period>(resource);
            var result = await _periodService.SaveAsync(period);

            if (!result.Success)
                return BadRequest(result.Message);

            var periodResource = _mapper.Map<Period, PeriodResource>(result.Resource);
            return Ok(periodResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PeriodResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePeriodResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var period = _mapper.Map<SavePeriodResource, Period>(resource);
            var result = await _periodService.UpdateAsync(id, period);

            if (!result.Success)
                return BadRequest(result.Message);

            var periodResource = _mapper.Map<Period, PeriodResource>(result.Resource);
            return Ok(periodResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PeriodResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _periodService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var personResource = _mapper.Map<Period, PeriodResource>(result.Resource);
            return Ok(personResource);
        }
    }
}
