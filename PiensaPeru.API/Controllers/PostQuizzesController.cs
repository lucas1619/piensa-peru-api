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
    public class PostQuizzesController : ControllerBase
    {
        private readonly IQuizService _quizService;
        private readonly IMapper _mapper;

        public PostQuizzesController(IQuizService quizService, IMapper mapper)
        {
            _quizService = quizService;
            _mapper = mapper;
        }

        //[HttpGet]
        //[ProducesResponseType(typeof(IEnumerable<QuizResource>), 200)]
        //public async Task<IEnumerable<QuizResource>> GetAllAsync()
        //{
        //    var quizs = await _quizService.ListAsync();
        //    var resources = _mapper
        //        .Map<IEnumerable<Quiz>, IEnumerable<QuizResource>>(quizs);
        //    return resources;
        //}

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<QuizResource>), 200)]
        public async Task<IEnumerable<QuizResource>> GetAllByPostIdAsync(int postId)
        {
            var quizs = await _quizService.ListByPostIdAsync(postId);
            var resources = _mapper
                .Map<IEnumerable<Quiz>, IEnumerable<QuizResource>>(quizs);
            return resources;
        }

        [HttpGet("{quizId}")]
        [ProducesResponseType(typeof(QuizResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int quizId)
        {
            var result = await _quizService.GetByIdAsync(quizId);
            if (!result.Success)
                return BadRequest(result.Message);
            var quizResource = _mapper.Map<Quiz, QuizResource>(result.Resource);
            return Ok(quizResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(QuizResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync(int postId, [FromBody] SaveQuizResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var quiz = _mapper.Map<SaveQuizResource, Quiz>(resource);
            var result = await _quizService.SaveAsync(postId, quiz);

            if (!result.Success)
                return BadRequest(result.Message);

            var quizResource = _mapper.Map<Quiz, QuizResource>(result.Resource);
            return Ok(quizResource);
        }

        [HttpPut("{quizId}")]
        [ProducesResponseType(typeof(QuizResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int quizId, [FromBody] SaveQuizResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var quiz = _mapper.Map<SaveQuizResource, Quiz>(resource);
            var result = await _quizService.UpdateAsync(quizId, quiz);

            if (!result.Success)
                return BadRequest(result.Message);

            var quizResource = _mapper.Map<Quiz, QuizResource>(result.Resource);
            return Ok(quizResource);
        }

        [HttpDelete("{quizId}")]
        [ProducesResponseType(typeof(PersonResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int quizId)
        {
            var result = await _quizService.DeleteAsync(quizId);

            if (!result.Success)
                return BadRequest(result.Message);

            var personResource = _mapper.Map<Quiz, QuizResource>(result.Resource);
            return Ok(personResource);
        }
    }
}
