using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PiensaPeru.API.Domain.Models.UserBoundedContextModels;
using PiensaPeru.API.Domain.Services.UserBoundedContextServices;
using PiensaPeru.API.Extensions;
using PiensaPeru.API.Resources.UserBoundedContextResources;

namespace PiensaPeru.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlansController : ControllerBase
    {
        private readonly IPlanService _planService;
        private readonly IMapper _mapper;

        public PlansController(IPlanService planService, IMapper mapper)
        {
            _planService = planService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PlanResource>), 200)]
        public async Task<IEnumerable<PlanResource>> GetAllAsync()
        {
            var plans = await _planService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Plan>, IEnumerable<PlanResource>>(plans);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PlanResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _planService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var planResource = _mapper.Map<Plan, PlanResource>(result.Resource);
            return Ok(planResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PlanResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SavePlanResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var plan = _mapper.Map<SavePlanResource, Plan>(resource);
            var result = await _planService.SaveAsync(plan);

            if (!result.Success)
                return BadRequest(result.Message);

            var planResource = _mapper.Map<Plan, PlanResource>(result.Resource);
            return Ok(planResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PlanResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePlanResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var plan = _mapper.Map<SavePlanResource, Plan>(resource);
            var result = await _planService.UpdateAsync(id, plan);

            if (!result.Success)
                return BadRequest(result.Message);

            var planResource = _mapper.Map<Plan, PlanResource>(result.Resource);
            return Ok(planResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PlanResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _planService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var personResource = _mapper.Map<Plan, PlanResource>(result.Resource);
            return Ok(personResource);
        }
    }
}
