using Microsoft.EntityFrameworkCore;
using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Persistence.Contexts;
using PiensaPeru.API.Domain.Persistence.Repositories;

namespace PiensaPeru.API.Persistence.Repositories
{
    public class QuizRepository : BaseRepository, IQuizRepository
    {
        public QuizRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Quiz quiz)
        {
            await _context.Quizzes.AddAsync(quiz);
        }

        public async Task<Quiz> FindById(int id)
        {
            return await _context.Quizzes.FindAsync(id);
        }

        public async Task<IEnumerable<Quiz>> ListAsync()
        {
            return await _context.Quizzes.ToListAsync();
        }

        public async Task<IEnumerable<Quiz>> ListByPostIdAsync(int postId)
        {
            return await _context.Quizzes
                .Where(q => q.PostId == postId)
                .Include(q => q.Post)
                .ToListAsync();
        }

        public void Remove(Quiz quiz)
        {
            _context.Quizzes.Remove(quiz);
        }

        public void Update(Quiz quiz)
        {
            _context.Quizzes.Update(quiz);
        }
    }
}
