using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PiensaPeru.API.Domain.Models.ContentBoundedContextModels;
using PiensaPeru.API.Domain.Services.ContentBoundedContextIServices;
using PiensaPeru.API.Extensions;
using PiensaPeru.API.Resources.ContentBoundedContextResources;
using Swashbuckle.AspNetCore.Annotations;

namespace PiensaPeru.API.Controllers.ContentBoundedContextControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MilitantContentsController : ControllerBase
    {
        private readonly IMilitantContentService _militantContentService;
        private readonly IMapper _mapper;

        public MilitantContentsController(IMilitantContentService militantContentService, IMapper mapper)
        {
            _militantContentService = militantContentService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MilitantContentResource>), 200)]
        public async Task<IEnumerable<MilitantContentResource>> GetAllAsync()
        {
            var militantContents = await _militantContentService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<MilitantContent>, IEnumerable<MilitantContentResource>>(militantContents);
            return resources;
        }

        [SwaggerOperation(
          Summary = "Assign Militant Content",
          Description = "Assign Militant Content",
          OperationId = "AssignMilitantContent")]
        [SwaggerResponse(200, "Assign Militant Content", typeof(MilitantContentResource))]
        [HttpPost]
        public async Task<IActionResult> AssignMilitantContentAsync([FromBody] SaveMilitantContentResource resource)
        {
            //var result = await _militantContentService.AssignMilitantContentAsync(militantId, contentId, periodId);
            //if (!result.Success)
            //    return BadRequest(result.Message);

            //var militantContentResource = _mapper.Map<MilitantContent, MilitantContentResource>(result.Resource);
            //return Ok(militantContentResource);

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var militantContent = _mapper.Map<SaveMilitantContentResource, MilitantContent>(resource);
            var result = await _militantContentService.AssignMilitantContentAsync(militantContent.MilitantId, militantContent.ContentId, militantContent.PeriodId);

            if (!result.Success)
                return BadRequest(result.Message);

            var militantContentResource = _mapper.Map<MilitantContent, MilitantContentResource>(result.Resource);
            return Ok(militantContentResource);
        }

        [HttpDelete("{militantId}")]
        public async Task<IActionResult> UnassignProfileTag(int militantId, int contentId)
        {
            var result = await _militantContentService.UnassignMilitantContentAsync(militantId, contentId);
            if (!result.Success)
                return BadRequest(result.Message);

            var militantContentResource = _mapper.Map<MilitantContent, MilitantContentResource>(result.Resource);
            return Ok(militantContentResource);
        }

        [HttpGet]
        [Route("militants/{militantId}")]
        [ProducesResponseType(typeof(IEnumerable<MilitantContentResource>), 200)]
        public async Task<IEnumerable<MilitantContentResource>> ListByMilitantIdAsync(int militantId)
        {
            var militantContents = await _militantContentService.ListByMilitantIdAsync(militantId);
            var resources = _mapper
                .Map<IEnumerable<MilitantContent>, IEnumerable<MilitantContentResource>>(militantContents);
            return resources;
        }

        [HttpGet]
        [Route("contents/{contentId}")]
        [ProducesResponseType(typeof(IEnumerable<MilitantContentResource>), 200)]
        public async Task<IEnumerable<MilitantContentResource>> ListByContentIdAsync(int contentId)
        {
            var militantContents = await _militantContentService.ListByContentIdAsync(contentId);
            var resources = _mapper
                .Map<IEnumerable<MilitantContent>, IEnumerable<MilitantContentResource>>(militantContents);
            return resources;
        }
    }
}
