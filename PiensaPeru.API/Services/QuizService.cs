using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Persistence.Repositories;
using PiensaPeru.API.Domain.Services;
using PiensaPeru.API.Domain.Services.Communications;

namespace PiensaPeru.API.Services
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepository;
        private readonly IUnitOfWork _unitOfWork;

        public QuizService(IQuizRepository quizRepository, IUnitOfWork unitOfWork)
        {
            _quizRepository = quizRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<QuizResponse> GetByIdAsync(int id)
        {
            var existingQuiz = await _quizRepository.FindById(id);

            if (existingQuiz == null)
                return new QuizResponse("Quiz not found");
            return new QuizResponse(existingQuiz);
        }

        public async Task<IEnumerable<Quiz>> ListAsync()
        {
            return await _quizRepository.ListAsync();
        }

        public async Task<QuizResponse> SaveAsync(int postId, Quiz quiz)
        {
            try
            {
                quiz.PostId = postId;
                await _quizRepository.AddAsync(quiz);
                await _unitOfWork.CompleteAsync();

                return new QuizResponse(quiz);
            }
            catch (Exception ex)
            {
                return new QuizResponse($"An error ocurred while saving the quiz: {ex.Message}");
            }
        }

        public async Task<QuizResponse> UpdateAsync(int id, Quiz quiz)
        {
            var existingQuiz = await _quizRepository.FindById(id);

            if (existingQuiz == null)
                return new QuizResponse("Quiz not found");

            existingQuiz.Title = quiz.Title;

            try
            {
                _quizRepository.Update(existingQuiz);
                await _unitOfWork.CompleteAsync();

                return new QuizResponse(existingQuiz);
            }
            catch (Exception ex)
            {
                return new QuizResponse($"An error ocurred while updating the quiz: {ex.Message}");
            }
        }

        public async Task<QuizResponse> DeleteAsync(int id)
        {
            var existingPerson = await _quizRepository.FindById(id);

            if (existingPerson == null)
                return new QuizResponse("Person not found");

            try
            {
                _quizRepository.Remove(existingPerson);
                await _unitOfWork.CompleteAsync();

                return new QuizResponse(existingPerson);
            }
            catch (Exception ex)
            {
                return new QuizResponse($"An error ocurred while deleting the person: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Quiz>> ListByPostIdAsync(int postId)
        {
            return await _quizRepository.ListByPostIdAsync(postId);
        }
    }
}
