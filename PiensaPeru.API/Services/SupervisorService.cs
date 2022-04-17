using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Persistence.Repositories;
using PiensaPeru.API.Domain.Services;
using PiensaPeru.API.Domain.Services.Communications;

namespace PiensaPeru.API.Services
{
    public class SupervisorService : ISupervisorService
    {
        private readonly ISupervisorRepository _supervisorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SupervisorService(ISupervisorRepository supervisorRepository, IUnitOfWork unitOfWork)
        {
            _supervisorRepository = supervisorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<SupervisorResponse> GetByIdAsync(int id)
        {
            var existingSupervisor = await _supervisorRepository.FindById(id);

            if (existingSupervisor == null)
                return new SupervisorResponse("Supervisor not found");
            return new SupervisorResponse(existingSupervisor);
        }

        public async Task<IEnumerable<Supervisor>> ListAsync()
        {
            return await _supervisorRepository.ListAsync();
        }

        public async Task<SupervisorResponse> SaveAsync(Supervisor supervisor)
        {
            try
            {
                //supervisor.PersonId = personId;
                await _supervisorRepository.AddAsync(supervisor);
                await _unitOfWork.CompleteAsync();

                return new SupervisorResponse(supervisor);
            }
            catch (Exception ex)
            {
                return new SupervisorResponse($"An error ocurred while saving the supervisor: {ex.Message}");
            }
        }

        public async Task<SupervisorResponse> UpdateAsync(int id, Supervisor supervisor)
        {
            var existingSupervisor = await _supervisorRepository.FindById(id);

            if (existingSupervisor == null)
                return new SupervisorResponse("Supervisor not found");

            existingSupervisor.Email = supervisor.Email;
            existingSupervisor.Password = supervisor.Password;
            existingSupervisor.FirstName = supervisor.FirstName;
            existingSupervisor.LastName = supervisor.LastName;

            try
            {
                _supervisorRepository.Update(existingSupervisor);
                await _unitOfWork.CompleteAsync();

                return new SupervisorResponse(existingSupervisor);
            }
            catch (Exception ex)
            {
                return new SupervisorResponse($"An error ocurred while updating the supervisor: {ex.Message}");
            }
        }

        public async Task<SupervisorResponse> DeleteAsync(int id)
        {
            var existingPerson = await _supervisorRepository.FindById(id);

            if (existingPerson == null)
                return new SupervisorResponse("Person not found");

            try
            {
                _supervisorRepository.Remove(existingPerson);
                await _unitOfWork.CompleteAsync();

                return new SupervisorResponse(existingPerson);
            }
            catch (Exception ex)
            {
                return new SupervisorResponse($"An error ocurred while deleting the person: {ex.Message}");
            }
        }
    }
}
