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
    public class PostParagraphsController : ControllerBase
    {
        private readonly IParagraphService _paragraphService;
        private readonly IMapper _mapper;

        public PostParagraphsController(IParagraphService paragraphService, IMapper mapper)
        {
            _paragraphService = paragraphService;
            _mapper = mapper;
        }

        //[HttpGet]
        //[ProducesResponseType(typeof(IEnumerable<ParagraphResource>), 200)]
        //public async Task<IEnumerable<ParagraphResource>> GetAllAsync()
        //{
        //    var paragraphs = await _paragraphService.ListAsync();
        //    var resources = _mapper
        //        .Map<IEnumerable<Paragraph>, IEnumerable<ParagraphResource>>(paragraphs);
        //    return resources;
        //}

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ParagraphResource>), 200)]
        public async Task<IEnumerable<ParagraphResource>> GetAllByPostIdAsync(int postId)
        {
            var paragraphs = await _paragraphService.ListByPostIdAsync(postId);
            var resources = _mapper
                .Map<IEnumerable<Paragraph>, IEnumerable<ParagraphResource>>(paragraphs);
            return resources;
        }

        [HttpGet("{paragraphId}")]
        [ProducesResponseType(typeof(ParagraphResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int paragraphId)
        {
            var result = await _paragraphService.GetByIdAsync(paragraphId);
            if (!result.Success)
                return BadRequest(result.Message);
            var paragraphResource = _mapper.Map<Paragraph, ParagraphResource>(result.Resource);
            return Ok(paragraphResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ParagraphResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync(int postId, [FromBody] SaveParagraphResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var paragraph = _mapper.Map<SaveParagraphResource, Paragraph>(resource);
            var result = await _paragraphService.SaveAsync(postId, paragraph);

            if (!result.Success)
                return BadRequest(result.Message);

            var paragraphResource = _mapper.Map<Paragraph, ParagraphResource>(result.Resource);
            return Ok(paragraphResource);
        }

        [HttpPut("{paragraphId}")]
        [ProducesResponseType(typeof(ParagraphResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int paragraphId, [FromBody] SaveParagraphResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var paragraph = _mapper.Map<SaveParagraphResource, Paragraph>(resource);
            var result = await _paragraphService.UpdateAsync(paragraphId, paragraph);

            if (!result.Success)
                return BadRequest(result.Message);

            var paragraphResource = _mapper.Map<Paragraph, ParagraphResource>(result.Resource);
            return Ok(paragraphResource);
        }

        [HttpDelete("{paragraphId}")]
        [ProducesResponseType(typeof(PersonResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int paragraphId)
        {
            var result = await _paragraphService.DeleteAsync(paragraphId);

            if (!result.Success)
                return BadRequest(result.Message);

            var personResource = _mapper.Map<Paragraph, ParagraphResource>(result.Resource);
            return Ok(personResource);
        }
    }
}
