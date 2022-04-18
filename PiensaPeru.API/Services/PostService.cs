using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Persistence.Repositories;
using PiensaPeru.API.Domain.Services;
using PiensaPeru.API.Domain.Services.Communications;

namespace PiensaPeru.API.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PostResponse> GetByIdAsync(int id)
        {
            var existingPost = await _postRepository.FindById(id);

            if (existingPost == null)
                return new PostResponse("Post not found");
            return new PostResponse(existingPost);
        }

        public async Task<IEnumerable<Post>> ListAsync()
        {
            return await _postRepository.ListAsync();
        }

        public async Task<PostResponse> SaveAsync(int supervisorId, int contentId, Post post)
        {
            try
            {
                post.SupervisorId = supervisorId;
                post.ContentId = contentId;
                await _postRepository.AddAsync(post);
                await _unitOfWork.CompleteAsync();

                return new PostResponse(post);
            }
            catch (Exception ex)
            {
                return new PostResponse($"An error ocurred while saving the post: {ex.Message}");
            }
        }

        public async Task<PostResponse> UpdateAsync(int id, Post post)
        {
            var existingPost = await _postRepository.FindById(id);

            if (existingPost == null)
                return new PostResponse("Post not found");

            existingPost.Title = post.Title;
            existingPost.AuthorName = post.AuthorName;
            existingPost.Tag = post.Tag;

            try
            {
                _postRepository.Update(existingPost);
                await _unitOfWork.CompleteAsync();

                return new PostResponse(existingPost);
            }
            catch (Exception ex)
            {
                return new PostResponse($"An error ocurred while updating the post: {ex.Message}");
            }
        }

        public async Task<PostResponse> DeleteAsync(int id)
        {
            var existingPerson = await _postRepository.FindById(id);

            if (existingPerson == null)
                return new PostResponse("Person not found");

            try
            {
                _postRepository.Remove(existingPerson);
                await _unitOfWork.CompleteAsync();

                return new PostResponse(existingPerson);
            }
            catch (Exception ex)
            {
                return new PostResponse($"An error ocurred while deleting the person: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Post>> ListBySupervisorIdAsync(int supervisorId)
        {
            return await _postRepository.ListBySupervisorIdAsync(supervisorId);
        }
    }
}
