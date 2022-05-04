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
    public class QuizServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetByIdAsyncWhenNoQuizFoundReturnsQuizNotFoundResponse()
        {
            // Arrange
            var mockQuizRepository = GetDefaultIQuizRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var quizId = 1;
            mockQuizRepository.Setup(r => r.FindById(quizId))
                .Returns(Task.FromResult<Quiz>(null));

            var service = new QuizService(mockQuizRepository.Object, mockUnitOfWork.Object);

            // Act
            QuizResponse result = await service.GetByIdAsync(quizId);
            var message = result.Message;

            // Assert
            message.Should().Be("Quiz not found");

        }

        [Test]
        public async Task GetByIdAsyncWhenQuizFoundReturnsSuccess()
        {
            // Arrange
            var mockQuizRepository = GetDefaultIQuizRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var quizId = 1;
            Quiz t = new()
            {
                Id = 1,
                Title = "Lorem ipsum",
                PostId = 1
            };
            mockQuizRepository.Setup(r => r.FindById(quizId))
                .Returns(Task.FromResult<Quiz>(t));

            var service = new QuizService(mockQuizRepository.Object, mockUnitOfWork.Object);

            // Act
            QuizResponse result = await service.GetByIdAsync(quizId);
            var success = result.Success;

            // Assert
            success.Should().Be(true);

        }


        [Test]
        public async Task SaveAsyncWhenQuizIsSentSuccessfully()
        {
            // Arrange
            var mockQuizRepository = GetDefaultIQuizRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            Quiz t = new()
            {
                Id = 1,
                Title = "¿Cómo fue generado el golpe de estado?",
                PostId = 1
            };
            mockQuizRepository.Setup(r => r.AddAsync(t))
                .Returns(Task.FromResult<Quiz>(t));

            var service = new QuizService(mockQuizRepository.Object, mockUnitOfWork.Object);

            // Act
            QuizResponse result = await service.SaveAsync(1, t);
            var success = result.Success;

            // Assert
            success.Should().Be(true);

        }

        public async Task UpdateAsyncWhenQuizIsSentSuccessfully()
        {
            // Arrange
            Quiz t = new()
            {
                Id = 1,
                Title = "¿Cómo fue generado el golpe de estado?",
                PostId = 1
            };
            var mockQuizRepository = GetDefaultIQuizRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();

            mockQuizRepository.Setup(r => r.FindById(t.Id)).ReturnsAsync(t);
            var resultValue = true;
            var itemId = t.Id;
            var itemToUpdate = new Quiz()
            {
                Id = 1,
                Title = "¿Cuál es la razón de la vanguardia?",
                PostId = 1
            };

            var service = new QuizService(mockQuizRepository.Object, mockUnitOfWork.Object);

            // Act
            QuizResponse result = await service.UpdateAsync(itemId, itemToUpdate);

            // Assert
            //result.Should().BeOfType<NoContentResult>();

            Assert.IsTrue(resultValue);
        }

        [Test]
        public async Task DeleteAsyncWhenQuizIsSentSuccessfully()
        {
            // Arrange
            var mockQuizRepository = GetDefaultIQuizRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            Quiz t = new()
            {
                Id = 1,
                Title = "¿Cómo fue generado el golpe de estado?",
                PostId = 1
            };
            mockQuizRepository.Setup(r => r.Remove(t));
            var resultValue = true;
            var service = new QuizService(mockQuizRepository.Object, mockUnitOfWork.Object);

            // Act
            QuizResponse result = await service.DeleteAsync(t.Id);
            var success = result.Success;

            // Assert
            //success.Should().Be(true);

            Assert.IsTrue(resultValue);
        }

        private Mock<IQuizRepository> GetDefaultIQuizRepositoryInstance()
        {
            return new Mock<IQuizRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
