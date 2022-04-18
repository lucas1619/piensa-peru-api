using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Services;
using PiensaPeru.API.Extensions;
using PiensaPeru.API.Resources;

namespace PiensaPeru.API.Controllers
{
    [Route("api/quizzes/{quizId}/[controller]")]
    [ApiController]
    public class QuizQuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;

        public QuizQuestionsController(IQuestionService questionService, IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        }

        //[HttpGet]
        //[ProducesResponseType(typeof(IEnumerable<QuestionResource>), 200)]
        //public async Task<IEnumerable<QuestionResource>> GetAllAsync()
        //{
        //    var questions = await _questionService.ListAsync();
        //    var resources = _mapper
        //        .Map<IEnumerable<Question>, IEnumerable<QuestionResource>>(questions);
        //    return resources;
        //}

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<QuestionResource>), 200)]
        public async Task<IEnumerable<QuestionResource>> GetAllByQuizIdAsync(int quizId)
        {
            var questions = await _questionService.ListByQuizIdAsync(quizId);
            var resources = _mapper
                .Map<IEnumerable<Question>, IEnumerable<QuestionResource>>(questions);
            return resources;
        }

        [HttpGet("{questionId}")]
        [ProducesResponseType(typeof(QuestionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int questionId)
        {
            var result = await _questionService.GetByIdAsync(questionId);
            if (!result.Success)
                return BadRequest(result.Message);
            var questionResource = _mapper.Map<Question, QuestionResource>(result.Resource);
            return Ok(questionResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(QuestionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync(int quizId, [FromBody] SaveQuestionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var question = _mapper.Map<SaveQuestionResource, Question>(resource);
            var result = await _questionService.SaveAsync(quizId, question);

            if (!result.Success)
                return BadRequest(result.Message);

            var questionResource = _mapper.Map<Question, QuestionResource>(result.Resource);
            return Ok(questionResource);
        }

        [HttpPut("{questionId}")]
        [ProducesResponseType(typeof(QuestionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int questionId, [FromBody] SaveQuestionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var question = _mapper.Map<SaveQuestionResource, Question>(resource);
            var result = await _questionService.UpdateAsync(questionId, question);

            if (!result.Success)
                return BadRequest(result.Message);

            var questionResource = _mapper.Map<Question, QuestionResource>(result.Resource);
            return Ok(questionResource);
        }

        [HttpDelete("{questionId}")]
        [ProducesResponseType(typeof(PersonResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int questionId)
        {
            var result = await _questionService.DeleteAsync(questionId);

            if (!result.Success)
                return BadRequest(result.Message);

            var personResource = _mapper.Map<Question, QuestionResource>(result.Resource);
            return Ok(personResource);
        }
    }
}
