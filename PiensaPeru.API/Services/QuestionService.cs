using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Persistence.Repositories;
using PiensaPeru.API.Domain.Services;
using PiensaPeru.API.Domain.Services.Communications;

namespace PiensaPeru.API.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public QuestionService(IQuestionRepository questionRepository, IUnitOfWork unitOfWork)
        {
            _questionRepository = questionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<QuestionResponse> GetByIdAsync(int id)
        {
            var existingQuestion = await _questionRepository.FindById(id);

            if (existingQuestion == null)
                return new QuestionResponse("Question not found");
            return new QuestionResponse(existingQuestion);
        }

        public async Task<IEnumerable<Question>> ListAsync()
        {
            return await _questionRepository.ListAsync();
        }

        public async Task<QuestionResponse> SaveAsync(int quizId, Question question)
        {
            try
            {
                question.QuizId = quizId;
                await _questionRepository.AddAsync(question);
                await _unitOfWork.CompleteAsync();

                return new QuestionResponse(question);
            }
            catch (Exception ex)
            {
                return new QuestionResponse($"An error ocurred while saving the question: {ex.Message}");
            }
        }

        public async Task<QuestionResponse> UpdateAsync(int id, Question question)
        {
            var existingQuestion = await _questionRepository.FindById(id);

            if (existingQuestion == null)
                return new QuestionResponse("Question not found");

            existingQuestion.Description = question.Description;

            try
            {
                _questionRepository.Update(existingQuestion);
                await _unitOfWork.CompleteAsync();

                return new QuestionResponse(existingQuestion);
            }
            catch (Exception ex)
            {
                return new QuestionResponse($"An error ocurred while updating the question: {ex.Message}");
            }
        }

        public async Task<QuestionResponse> DeleteAsync(int id)
        {
            var existingPerson = await _questionRepository.FindById(id);

            if (existingPerson == null)
                return new QuestionResponse("Person not found");

            try
            {
                _questionRepository.Remove(existingPerson);
                await _unitOfWork.CompleteAsync();

                return new QuestionResponse(existingPerson);
            }
            catch (Exception ex)
            {
                return new QuestionResponse($"An error ocurred while deleting the person: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Question>> ListByQuizIdAsync(int quizId)
        {
            return await _questionRepository.ListByQuizIdAsync(quizId);
        }
    }
}
