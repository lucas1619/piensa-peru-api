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
