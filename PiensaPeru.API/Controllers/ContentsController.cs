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
    public class ContentsController : ControllerBase
    {
        private readonly IContentService _contentService;
        private readonly IMapper _mapper;

        public ContentsController(IContentService contentService, IMapper mapper)
        {
            _contentService = contentService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ContentResource>), 200)]
        public async Task<IEnumerable<ContentResource>> GetAllAsync()
        {
            var contents = await _contentService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Content>, IEnumerable<ContentResource>>(contents);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ContentResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _contentService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var contentResource = _mapper.Map<Content, ContentResource>(result.Resource);
            return Ok(contentResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ContentResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveContentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var content = _mapper.Map<SaveContentResource, Content>(resource);
            var result = await _contentService.SaveAsync(content);

            if (!result.Success)
                return BadRequest(result.Message);

            var contentResource = _mapper.Map<Content, ContentResource>(result.Resource);
            return Ok(contentResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ContentResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveContentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var content = _mapper.Map<SaveContentResource, Content>(resource);
            var result = await _contentService.UpdateAsync(id, content);

            if (!result.Success)
                return BadRequest(result.Message);

            var contentResource = _mapper.Map<Content, ContentResource>(result.Resource);
            return Ok(contentResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ContentResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _contentService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var personResource = _mapper.Map<Content, ContentResource>(result.Resource);
            return Ok(personResource);
        }
    }
}
