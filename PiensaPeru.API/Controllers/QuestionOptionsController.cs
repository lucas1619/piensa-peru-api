using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Services;
using PiensaPeru.API.Extensions;
using PiensaPeru.API.Resources;

namespace PiensaPeru.API.Controllers
{
    [Route("api/questions/{questionId}/[controller]")]
    [ApiController]
    public class QuestionOptionsController : ControllerBase
    {
        private readonly IOptionService _optionService;
        private readonly IMapper _mapper;

        public QuestionOptionsController(IOptionService optionService, IMapper mapper)
        {
            _optionService = optionService;
            _mapper = mapper;
        }

        //[HttpGet]
        //[ProducesResponseType(typeof(IEnumerable<OptionResource>), 200)]
        //public async Task<IEnumerable<OptionResource>> GetAllAsync()
        //{
        //    var options = await _optionService.ListAsync();
        //    var resources = _mapper
        //        .Map<IEnumerable<Option>, IEnumerable<OptionResource>>(options);
        //    return resources;
        //}

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OptionResource>), 200)]
        public async Task<IEnumerable<OptionResource>> GetAllByQuestionIdAsync(int questionId)
        {
            var options = await _optionService.ListByQuestionIdAsync(questionId);
            var resources = _mapper
                .Map<IEnumerable<Option>, IEnumerable<OptionResource>>(options);
            return resources;
        }

        [HttpGet("{optionId}")]
        [ProducesResponseType(typeof(OptionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int optionId)
        {
            var result = await _optionService.GetByIdAsync(optionId);
            if (!result.Success)
                return BadRequest(result.Message);
            var optionResource = _mapper.Map<Option, OptionResource>(result.Resource);
            return Ok(optionResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(OptionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync(int questionId, [FromBody] SaveOptionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var option = _mapper.Map<SaveOptionResource, Option>(resource);
            var result = await _optionService.SaveAsync(questionId, option);

            if (!result.Success)
                return BadRequest(result.Message);

            var optionResource = _mapper.Map<Option, OptionResource>(result.Resource);
            return Ok(optionResource);
        }

        [HttpPut("{optionId}")]
        [ProducesResponseType(typeof(OptionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int optionId, [FromBody] SaveOptionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var option = _mapper.Map<SaveOptionResource, Option>(resource);
            var result = await _optionService.UpdateAsync(optionId, option);

            if (!result.Success)
                return BadRequest(result.Message);

            var optionResource = _mapper.Map<Option, OptionResource>(result.Resource);
            return Ok(optionResource);
        }

        [HttpDelete("{optionId}")]
        [ProducesResponseType(typeof(PersonResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int optionId)
        {
            var result = await _optionService.DeleteAsync(optionId);

            if (!result.Success)
                return BadRequest(result.Message);

            var personResource = _mapper.Map<Option, OptionResource>(result.Resource);
            return Ok(personResource);
        }
    }
}
