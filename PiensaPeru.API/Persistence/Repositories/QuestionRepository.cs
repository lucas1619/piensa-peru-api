using Microsoft.EntityFrameworkCore;
using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Persistence.Contexts;
using PiensaPeru.API.Domain.Persistence.Repositories;

namespace PiensaPeru.API.Persistence.Repositories
{
    public class QuestionRepository : BaseRepository, IQuestionRepository
    {
        public QuestionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Question question)
        {
            await _context.Questions.AddAsync(question);
        }

        public async Task<Question> FindById(int id)
        {
            return await _context.Questions.FindAsync(id);
        }

        public async Task<IEnumerable<Question>> ListAsync()
        {
            return await _context.Questions.ToListAsync();
        }

        public async Task<IEnumerable<Question>> ListByQuizIdAsync(int quizId)
        {
            return await _context.Questions
                .Where(q => q.QuizId == quizId)
                .Include(q => q.Quiz)
                .ToListAsync();
        }

        public void Remove(Question question)
        {
            _context.Questions.Remove(question);
        }

        public void Update(Question question)
        {
            _context.Questions.Update(question);
        }
    }
}
