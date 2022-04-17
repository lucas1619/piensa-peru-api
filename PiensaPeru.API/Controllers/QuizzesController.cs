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
    public class QuizzesController : ControllerBase
    {
        private readonly IQuizService _quizService;
        private readonly IMapper _mapper;

        public QuizzesController(IQuizService quizService, IMapper mapper)
        {
            _quizService = quizService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<QuizResource>), 200)]
        public async Task<IEnumerable<QuizResource>> GetAllAsync()
        {
            var quizs = await _quizService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Quiz>, IEnumerable<QuizResource>>(quizs);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(QuizResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _quizService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var quizResource = _mapper.Map<Quiz, QuizResource>(result.Resource);
            return Ok(quizResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(QuizResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveQuizResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var quiz = _mapper.Map<SaveQuizResource, Quiz>(resource);
            var result = await _quizService.SaveAsync(quiz);

            if (!result.Success)
                return BadRequest(result.Message);

            var quizResource = _mapper.Map<Quiz, QuizResource>(result.Resource);
            return Ok(quizResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(QuizResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveQuizResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var quiz = _mapper.Map<SaveQuizResource, Quiz>(resource);
            var result = await _quizService.UpdateAsync(id, quiz);

            if (!result.Success)
                return BadRequest(result.Message);

            var quizResource = _mapper.Map<Quiz, QuizResource>(result.Resource);
            return Ok(quizResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(QuizResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _quizService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var personResource = _mapper.Map<Quiz, QuizResource>(result.Resource);
            return Ok(personResource);
        }
    }
}
