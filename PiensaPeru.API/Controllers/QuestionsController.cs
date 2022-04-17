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
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;

        public QuestionsController(IQuestionService questionService, IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<QuestionResource>), 200)]
        public async Task<IEnumerable<QuestionResource>> GetAllAsync()
        {
            var questions = await _questionService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Question>, IEnumerable<QuestionResource>>(questions);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(QuestionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _questionService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var questionResource = _mapper.Map<Question, QuestionResource>(result.Resource);
            return Ok(questionResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(QuestionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveQuestionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var question = _mapper.Map<SaveQuestionResource, Question>(resource);
            var result = await _questionService.SaveAsync(question);

            if (!result.Success)
                return BadRequest(result.Message);

            var questionResource = _mapper.Map<Question, QuestionResource>(result.Resource);
            return Ok(questionResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(QuestionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveQuestionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var question = _mapper.Map<SaveQuestionResource, Question>(resource);
            var result = await _questionService.UpdateAsync(id, question);

            if (!result.Success)
                return BadRequest(result.Message);

            var questionResource = _mapper.Map<Question, QuestionResource>(result.Resource);
            return Ok(questionResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(QuestionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _questionService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var personResource = _mapper.Map<Question, QuestionResource>(result.Resource);
            return Ok(personResource);
        }
    }
}
