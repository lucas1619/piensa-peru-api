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
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostsController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PostResource>), 200)]
        public async Task<IEnumerable<PostResource>> GetAllAsync()
        {
            var posts = await _postService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Post>, IEnumerable<PostResource>>(posts);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PostResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _postService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var postResource = _mapper.Map<Post, PostResource>(result.Resource);
            return Ok(postResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PostResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SavePostResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var post = _mapper.Map<SavePostResource, Post>(resource);
            var result = await _postService.SaveAsync(post);

            if (!result.Success)
                return BadRequest(result.Message);

            var postResource = _mapper.Map<Post, PostResource>(result.Resource);
            return Ok(postResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PostResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePostResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var post = _mapper.Map<SavePostResource, Post>(resource);
            var result = await _postService.UpdateAsync(id, post);

            if (!result.Success)
                return BadRequest(result.Message);

            var postResource = _mapper.Map<Post, PostResource>(result.Resource);
            return Ok(postResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PersonResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _postService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var personResource = _mapper.Map<Post, PostResource>(result.Resource);
            return Ok(personResource);
        }
    }
}
