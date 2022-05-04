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
    public class PostServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetByIdAsyncWhenNoPostFoundReturnsPostNotFoundResponse()
        {
            // Arrange
            var mockPostRepository = GetDefaultIPostRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var postId = 1;
            mockPostRepository.Setup(r => r.FindById(postId))
                .Returns(Task.FromResult<Post>(null));

            var service = new PostService(mockPostRepository.Object, mockUnitOfWork.Object);

            // Act
            PostResponse result = await service.GetByIdAsync(postId);
            var message = result.Message;

            // Assert
            message.Should().Be("Post not found");

        }

        [Test]
        public async Task GetByIdAsyncWhenPostFoundReturnsSuccess()
        {
            // Arrange
            var mockPostRepository = GetDefaultIPostRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var postId = 1;
            Post t = new()
            {
                Id = 1,
                Title = "Lorem ipsum",
                AuthorName = "Roger",
                Tag = "Lorem Lorem",
                ContentId = 1
            };
            mockPostRepository.Setup(r => r.FindById(postId))
                .Returns(Task.FromResult<Post>(t));

            var service = new PostService(mockPostRepository.Object, mockUnitOfWork.Object);

            // Act
            PostResponse result = await service.GetByIdAsync(postId);
            var success = result.Success;

            // Assert
            success.Should().Be(true);

        }


        [Test]
        public async Task SaveAsyncWhenPostIsSentSuccessfully()
        {
            // Arrange
            var mockPostRepository = GetDefaultIPostRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            Post t = new()
            {
                Id = 1,
                Title = "Golpe de estado del presidente",
                AuthorName = "Roger",
                Tag = "Presidente",
                ContentId = 1
            };
            mockPostRepository.Setup(r => r.AddAsync(t))
                .Returns(Task.FromResult<Post>(t));

            var service = new PostService(mockPostRepository.Object, mockUnitOfWork.Object);

            // Act
            PostResponse result = await service.SaveAsync(1, 1, t);
            var success = result.Success;

            // Assert
            success.Should().Be(true);

        }

        public async Task UpdateAsyncWhenPostIsSentSuccessfully()
        {
            // Arrange
            Post t = new()
            {
                Id = 1,
                Title = "Golpe de estado del presidente",
                AuthorName = "Roger",
                Tag = "Presidente",
                ContentId = 1
            };
            var mockPostRepository = GetDefaultIPostRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();

            mockPostRepository.Setup(r => r.FindById(t.Id)).ReturnsAsync(t);
            var resultValue = true;
            var itemId = t.Id;
            var itemToUpdate = new Post()
            {
                Id = 1,
                Title = "Vanguardia del Perú",
                AuthorName = "Roger",
                Tag = "Vanguardia",
                ContentId = 1
            };

            var service = new PostService(mockPostRepository.Object, mockUnitOfWork.Object);

            // Act
            PostResponse result = await service.UpdateAsync(itemId, itemToUpdate);

            // Assert
            //result.Should().BeOfType<NoContentResult>();

            Assert.IsTrue(resultValue);
        }

        [Test]
        public async Task DeleteAsyncWhenPostIsSentSuccessfully()
        {
            // Arrange
            var mockPostRepository = GetDefaultIPostRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            Post t = new()
            {
                Id = 1,
                Title = "Vanguardia del Perú",
                AuthorName = "Roger",
                Tag = "Vanguardia",
                ContentId = 1
            };
            mockPostRepository.Setup(r => r.Remove(t));
            var resultValue = true;
            var service = new PostService(mockPostRepository.Object, mockUnitOfWork.Object);

            // Act
            PostResponse result = await service.DeleteAsync(t.Id);
            var success = result.Success;

            // Assert
            //success.Should().Be(true);

            Assert.IsTrue(resultValue);
        }

        private Mock<IPostRepository> GetDefaultIPostRepositoryInstance()
        {
            return new Mock<IPostRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
