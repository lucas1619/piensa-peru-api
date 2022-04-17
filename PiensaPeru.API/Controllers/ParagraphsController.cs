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
    public class ParagraphsController : ControllerBase
    {
        private readonly IParagraphService _paragraphService;
        private readonly IMapper _mapper;

        public ParagraphsController(IParagraphService paragraphService, IMapper mapper)
        {
            _paragraphService = paragraphService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ParagraphResource>), 200)]
        public async Task<IEnumerable<ParagraphResource>> GetAllAsync()
        {
            var paragraphs = await _paragraphService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Paragraph>, IEnumerable<ParagraphResource>>(paragraphs);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ParagraphResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _paragraphService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var paragraphResource = _mapper.Map<Paragraph, ParagraphResource>(result.Resource);
            return Ok(paragraphResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ParagraphResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveParagraphResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var paragraph = _mapper.Map<SaveParagraphResource, Paragraph>(resource);
            var result = await _paragraphService.SaveAsync(paragraph);

            if (!result.Success)
                return BadRequest(result.Message);

            var paragraphResource = _mapper.Map<Paragraph, ParagraphResource>(result.Resource);
            return Ok(paragraphResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ParagraphResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveParagraphResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var paragraph = _mapper.Map<SaveParagraphResource, Paragraph>(resource);
            var result = await _paragraphService.UpdateAsync(id, paragraph);

            if (!result.Success)
                return BadRequest(result.Message);

            var paragraphResource = _mapper.Map<Paragraph, ParagraphResource>(result.Resource);
            return Ok(paragraphResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ParagraphResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _paragraphService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var personResource = _mapper.Map<Paragraph, ParagraphResource>(result.Resource);
            return Ok(personResource);
        }
    }
}
