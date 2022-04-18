using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Persistence.Repositories;
using PiensaPeru.API.Domain.Services;
using PiensaPeru.API.Domain.Services.Communications;

namespace PiensaPeru.API.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ImageService(IImageRepository imageRepository, IUnitOfWork unitOfWork)
        {
            _imageRepository = imageRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ImageResponse> GetByIdAsync(int id)
        {
            var existingImage = await _imageRepository.FindById(id);

            if (existingImage == null)
                return new ImageResponse("Image not found");
            return new ImageResponse(existingImage);
        }

        public async Task<IEnumerable<Image>> ListAsync()
        {
            return await _imageRepository.ListAsync();
        }

        public async Task<ImageResponse> SaveAsync(int postId, Image image)
        {
            try
            {
                //image.PersonId = personId;
                await _imageRepository.AddAsync(image);
                await _unitOfWork.CompleteAsync();

                return new ImageResponse(image);
            }
            catch (Exception ex)
            {
                return new ImageResponse($"An error ocurred while saving the image: {ex.Message}");
            }
        }

        public async Task<ImageResponse> UpdateAsync(int id, Image image)
        {
            var existingImage = await _imageRepository.FindById(id);

            if (existingImage == null)
                return new ImageResponse("Image not found");

            existingImage.Title = image.Title;
            existingImage.Url = image.Url;

            try
            {
                _imageRepository.Update(existingImage);
                await _unitOfWork.CompleteAsync();

                return new ImageResponse(existingImage);
            }
            catch (Exception ex)
            {
                return new ImageResponse($"An error ocurred while updating the image: {ex.Message}");
            }
        }

        public async Task<ImageResponse> DeleteAsync(int id)
        {
            var existingPerson = await _imageRepository.FindById(id);

            if (existingPerson == null)
                return new ImageResponse("Person not found");

            try
            {
                _imageRepository.Remove(existingPerson);
                await _unitOfWork.CompleteAsync();

                return new ImageResponse(existingPerson);
            }
            catch (Exception ex)
            {
                return new ImageResponse($"An error ocurred while deleting the person: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Image>> ListByPostIdAsync(int postId)
        {
            return await _imageRepository.ListByPostIdAsync(postId);
        }
    }
}
