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
    public class PostTypesController : ControllerBase
    {
        private readonly IPostTypeService _postTypeService;
        private readonly IMapper _mapper;

        public PostTypesController(IPostTypeService postTypeService, IMapper mapper)
        {
            _postTypeService = postTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PostTypeResource>), 200)]
        public async Task<IEnumerable<PostTypeResource>> GetAllAsync()
        {
            var postTypes = await _postTypeService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<PostType>, IEnumerable<PostTypeResource>>(postTypes);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PostTypeResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _postTypeService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var postTypeResource = _mapper.Map<PostType, PostTypeResource>(result.Resource);
            return Ok(postTypeResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PostTypeResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SavePostTypeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var postType = _mapper.Map<SavePostTypeResource, PostType>(resource);
            var result = await _postTypeService.SaveAsync(postType);

            if (!result.Success)
                return BadRequest(result.Message);

            var postTypeResource = _mapper.Map<PostType, PostTypeResource>(result.Resource);
            return Ok(postTypeResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PostTypeResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePostTypeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var postType = _mapper.Map<SavePostTypeResource, PostType>(resource);
            var result = await _postTypeService.UpdateAsync(id, postType);

            if (!result.Success)
                return BadRequest(result.Message);

            var postTypeResource = _mapper.Map<PostType, PostTypeResource>(result.Resource);
            return Ok(postTypeResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PostTypeResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _postTypeService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var personResource = _mapper.Map<PostType, PostTypeResource>(result.Resource);
            return Ok(personResource);
        }
    }
}
