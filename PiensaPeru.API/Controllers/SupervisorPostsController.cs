using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Services;
using PiensaPeru.API.Extensions;
using PiensaPeru.API.Resources;

namespace PiensaPeru.API.Controllers
{
    [Route("api/supervisors/{supervisorId}/posts")]
    [ApiController]
    public class SupervisorPostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public SupervisorPostsController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PostResource>), 200)]
        public async Task<IEnumerable<PostResource>> GetAllBySupervisorIdAsync(int supervisorId)
        {
            var posts = await _postService.ListBySupervisorIdAsync(supervisorId);
            var resources = _mapper
                .Map<IEnumerable<Post>, IEnumerable<PostResource>>(posts);
            return resources;
        }

        [HttpGet("{postId}")]
        [ProducesResponseType(typeof(PostResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int postId)
        {
            var result = await _postService.GetByIdAsync(postId);
            if (!result.Success)
                return BadRequest(result.Message);
            var postResource = _mapper.Map<Post, PostResource>(result.Resource);
            return Ok(postResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PostResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync(int supervisorId, int contentId, [FromBody] SavePostResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var post = _mapper.Map<SavePostResource, Post>(resource);
            var result = await _postService.SaveAsync(supervisorId, contentId, post);

            if (!result.Success)
                return BadRequest(result.Message);

            var postResource = _mapper.Map<Post, PostResource>(result.Resource);
            return Ok(postResource);
        }

        [HttpPut("{postId}")]
        [ProducesResponseType(typeof(PostResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int postId, [FromBody] SavePostResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var post = _mapper.Map<SavePostResource, Post>(resource);
            var result = await _postService.UpdateAsync(postId, post);

            if (!result.Success)
                return BadRequest(result.Message);

            var postResource = _mapper.Map<Post, PostResource>(result.Resource);
            return Ok(postResource);
        }

        [HttpDelete("{postId}")]
        [ProducesResponseType(typeof(PersonResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int postId)
        {
            var result = await _postService.DeleteAsync(postId);

            if (!result.Success)
                return BadRequest(result.Message);

            var personResource = _mapper.Map<Post, PostResource>(result.Resource);
            return Ok(personResource);
        }
    }
}
