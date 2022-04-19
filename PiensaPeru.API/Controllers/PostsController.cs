using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Services;
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

        [HttpGet("types")]
        [ProducesResponseType(typeof(IEnumerable<PostTypeResource>), 200)]
        public async Task<IEnumerable<PostTypeResource>> GetAllPostTypesAsync()
        {
            var posts = await _postService.ListPostTypesAsync();
            var resources = _mapper
                .Map<IEnumerable<Post>, IEnumerable<PostTypeResource>>(posts);
            return resources;
        }
    }
}
