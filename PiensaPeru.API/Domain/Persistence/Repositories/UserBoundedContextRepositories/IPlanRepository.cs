using PiensaPeru.API.Domain.Models.UserBoundedContextModels;

namespace PiensaPeru.API.Domain.Persistence.Repositories.UserBoundedContextRepositories
{
    public interface IPlanRepository
    {
        Task<IEnumerable<Plan>> ListAsync();
        Task<Plan> FindById(int id);
        Task AddAsync(Plan plan);
        void Update(Plan plan);
        void Remove(Plan plan);
    }
}
