using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Persistence.Repositories;
using PiensaPeru.API.Domain.Services;
using PiensaPeru.API.Domain.Services.Communications;

namespace PiensaPeru.API.Services
{
    public class PostTypeService : IPostTypeService
    {
        private readonly IPostTypeRepository _postTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PostTypeService(IPostTypeRepository postTypeRepository, IUnitOfWork unitOfWork)
        {
            _postTypeRepository = postTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PostTypeResponse> GetByIdAsync(int id)
        {
            var existingPostType = await _postTypeRepository.FindById(id);

            if (existingPostType == null)
                return new PostTypeResponse("PostType not found");
            return new PostTypeResponse(existingPostType);
        }

        public async Task<IEnumerable<PostType>> ListAsync()
        {
            return await _postTypeRepository.ListAsync();
        }

        public async Task<PostTypeResponse> SaveAsync(PostType postType)
        {
            try
            {
                //postType.PersonId = personId;
                await _postTypeRepository.AddAsync(postType);
                await _unitOfWork.CompleteAsync();

                return new PostTypeResponse(postType);
            }
            catch (Exception ex)
            {
                return new PostTypeResponse($"An error ocurred while saving the postType: {ex.Message}");
            }
        }

        public async Task<PostTypeResponse> UpdateAsync(int id, PostType postType)
        {
            var existingPostType = await _postTypeRepository.FindById(id);

            if (existingPostType == null)
                return new PostTypeResponse("PostType not found");

            existingPostType.Name = postType.Name;

            try
            {
                _postTypeRepository.Update(existingPostType);
                await _unitOfWork.CompleteAsync();

                return new PostTypeResponse(existingPostType);
            }
            catch (Exception ex)
            {
                return new PostTypeResponse($"An error ocurred while updating the postType: {ex.Message}");
            }
        }

        public async Task<PostTypeResponse> DeleteAsync(int id)
        {
            var existingPerson = await _postTypeRepository.FindById(id);

            if (existingPerson == null)
                return new PostTypeResponse("Person not found");

            try
            {
                _postTypeRepository.Remove(existingPerson);
                await _unitOfWork.CompleteAsync();

                return new PostTypeResponse(existingPerson);
            }
            catch (Exception ex)
            {
                return new PostTypeResponse($"An error ocurred while deleting the person: {ex.Message}");
            }
        }
    }
}
