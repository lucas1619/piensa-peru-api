using FluentAssertions;
using Moq;
using NUnit.Framework;
using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Persistence.Repositories;
using PiensaPeru.API.Domain.Services.Communications;
using PiensaPeru.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiensaPeru.API.Tests
{
    public class imageServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetByIdAsyncWhenNoImageFoundReturnsImageNotFoundResponse()
        {
            // Arrange
            var mockImageRepository = GetDefaultIImageRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var imageId = 1;
            mockImageRepository.Setup(r => r.FindById(imageId))
                .Returns(Task.FromResult<Image>(null));

            var service = new ImageService(mockImageRepository.Object, mockUnitOfWork.Object);

            // Act
            ImageResponse result = await service.GetByIdAsync(imageId);
            var message = result.Message;

            // Assert
            message.Should().Be("Image not found");

        }

        [Test]
        public async Task GetByIdAsyncWhenImageFoundReturnsSuccess()
        {
            // Arrange
            var mockImageRepository = GetDefaultIImageRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var imageId = 1;
            Image t = new()
            {
                Id = 1,
                Title = "Lorem ipsum",
                Url = "www.piensaperu/images.com",
                PostId = 1
            };
            mockImageRepository.Setup(r => r.FindById(imageId))
                .Returns(Task.FromResult<Image>(t));

            var service = new ImageService(mockImageRepository.Object, mockUnitOfWork.Object);

            // Act
            ImageResponse result = await service.GetByIdAsync(imageId);
            var success = result.Success;

            // Assert
            success.Should().Be(true);

        }

        private Mock<IImageRepository> GetDefaultIImageRepositoryInstance()
        {
            return new Mock<IImageRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
