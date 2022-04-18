using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Services;
using PiensaPeru.API.Extensions;
using PiensaPeru.API.Resources;

namespace PiensaPeru.API.Controllers
{
    [Route("api/posts/{postId}/[controller]")]
    [ApiController]
    public class PostImagesController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public PostImagesController(IImageService imageService, IMapper mapper)
        {
            _imageService = imageService;
            _mapper = mapper;
        }

        //[HttpGet]
        //[ProducesResponseType(typeof(IEnumerable<ImageResource>), 200)]
        //public async Task<IEnumerable<ImageResource>> GetAllAsync()
        //{
        //    var images = await _imageService.ListAsync();
        //    var resources = _mapper
        //        .Map<IEnumerable<Image>, IEnumerable<ImageResource>>(images);
        //    return resources;
        //}

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ImageResource>), 200)]
        public async Task<IEnumerable<ImageResource>> GetAllByPostIdAsync(int postId)
        {
            var images = await _imageService.ListByPostIdAsync(postId);
            var resources = _mapper
                .Map<IEnumerable<Image>, IEnumerable<ImageResource>>(images);
            return resources;
        }

        [HttpGet("{imageId}")]
        [ProducesResponseType(typeof(ImageResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int imageId)
        {
            var result = await _imageService.GetByIdAsync(imageId);
            if (!result.Success)
                return BadRequest(result.Message);
            var imageResource = _mapper.Map<Image, ImageResource>(result.Resource);
            return Ok(imageResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ImageResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync(int postId, [FromBody] SaveImageResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var image = _mapper.Map<SaveImageResource, Image>(resource);
            var result = await _imageService.SaveAsync(postId, image);

            if (!result.Success)
                return BadRequest(result.Message);

            var imageResource = _mapper.Map<Image, ImageResource>(result.Resource);
            return Ok(imageResource);
        }

        [HttpPut("{imageId}")]
        [ProducesResponseType(typeof(ImageResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int imageId, [FromBody] SaveImageResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var image = _mapper.Map<SaveImageResource, Image>(resource);
            var result = await _imageService.UpdateAsync(imageId, image);

            if (!result.Success)
                return BadRequest(result.Message);

            var imageResource = _mapper.Map<Image, ImageResource>(result.Resource);
            return Ok(imageResource);
        }

        [HttpDelete("{imageId}")]
        [ProducesResponseType(typeof(PersonResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int imageId)
        {
            var result = await _imageService.DeleteAsync(imageId);

            if (!result.Success)
                return BadRequest(result.Message);

            var personResource = _mapper.Map<Image, ImageResource>(result.Resource);
            return Ok(personResource);
        }        
    }
}
