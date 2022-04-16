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
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public ImagesController(IImageService imageService, IMapper mapper)
        {
            _imageService = imageService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ImageResource>), 200)]
        public async Task<IEnumerable<ImageResource>> GetAllAsync()
        {
            var images = await _imageService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Image>, IEnumerable<ImageResource>>(images);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ImageResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _imageService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var imageResource = _mapper.Map<Image, ImageResource>(result.Resource);
            return Ok(imageResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ImageResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveImageResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var image = _mapper.Map<SaveImageResource, Image>(resource);
            var result = await _imageService.SaveAsync(image);

            if (!result.Success)
                return BadRequest(result.Message);

            var imageResource = _mapper.Map<Image, ImageResource>(result.Resource);
            return Ok(imageResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ImageResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveImageResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var image = _mapper.Map<SaveImageResource, Image>(resource);
            var result = await _imageService.UpdateAsync(id, image);

            if (!result.Success)
                return BadRequest(result.Message);

            var imageResource = _mapper.Map<Image, ImageResource>(result.Resource);
            return Ok(imageResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PersonResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _imageService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var personResource = _mapper.Map<Image, ImageResource>(result.Resource);
            return Ok(personResource);
        }        
    }
}
