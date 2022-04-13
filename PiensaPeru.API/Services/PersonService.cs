using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Persistence.Repositories;
using PiensaPeru.API.Domain.Services;
using PiensaPeru.API.Domain.Services.Communications;

namespace PiensaPeru.API.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PersonService(IPersonRepository personRepository, IUnitOfWork unitOfWork)
        {
            _personRepository = personRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PersonResponse> DeleteAsync(int id)
        {
            var existingPerson = await _personRepository.FindById(id);

            if (existingPerson == null)
                return new PersonResponse("Person not found");

            try
            {
                _personRepository.Remove(existingPerson);
                await _unitOfWork.CompleteAsync();

                return new PersonResponse(existingPerson);
            }
            catch (Exception ex)
            {
                return new PersonResponse($"An error ocurred while deleting the person: {ex.Message}");
            }
        }

        public async Task<PersonResponse> GetByIdAsync(int id)
        {
            var existingPerson = await _personRepository.FindById(id);

            if (existingPerson == null)
                return new PersonResponse("Person not found");
            return new PersonResponse(existingPerson);
        }

        public async Task<IEnumerable<Person>> ListAsync()
        {
            return await _personRepository.ListAsync();
        }

        public async Task<PersonResponse> SaveAsync(Person person)
        {
            try
            {
                await _personRepository.AddAsync(person);
                await _unitOfWork.CompleteAsync();

                return new PersonResponse(person);
            }
            catch (Exception ex)
            {
                return new PersonResponse($"An error ocurred while saving the person: {ex.Message}");
            }
        }

        public async Task<PersonResponse> UpdateAsync(int id, Person person)
        {
            var existingPerson = await _personRepository.FindById(id);

            if (existingPerson == null)
                return new PersonResponse("Person not found");

            existingPerson.FirstName = person.FirstName;
            existingPerson.LastName = person.LastName;

            try
            {
                _personRepository.Update(existingPerson);
                await _unitOfWork.CompleteAsync();

                return new PersonResponse(existingPerson);
            }
            catch (Exception ex)
            {
                return new PersonResponse($"An error ocurred while updating the person: {ex.Message}");
            }
        }
    }
}
