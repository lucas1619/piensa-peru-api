using PiensaPeru.API.Domain.Models.UserBoundedContextModels;

namespace PiensaPeru.API.Domain.Persistence.Repositories.UserBoundedContextRepositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task<User> FindById(int id);
        Task AddAsync(User user);
        void Update(User user);
        void Remove(User user);
    }
}
