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
    public class SupervisorServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetByIdAsyncWhenNoSupervisorFoundReturnsSupervisorNotFoundResponse()
        {
            // Arrange
            var mockSupervisorRepository = GetDefaultISupervisorRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var supervisorId = 1;
            mockSupervisorRepository.Setup(r => r.FindById(supervisorId))
                .Returns(Task.FromResult<Supervisor>(null));

            var service = new SupervisorService(mockSupervisorRepository.Object, mockUnitOfWork.Object);

            // Act
            SupervisorResponse result = await service.GetByIdAsync(supervisorId);
            var message = result.Message;

            // Assert
            message.Should().Be("Supervisor not found");

        }

        [Test]
        public async Task GetByIdAsyncWhenSupervisorFoundReturnsSuccess()
        {
            // Arrange
            var mockSupervisorRepository = GetDefaultISupervisorRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var supervisorId = 1;
            Supervisor t = new()
            {
                Id = 1,
                FirstName = "Roger",
                LastName = "Sech",
                Email = "roier123@hotmail.com",
                Password = "maincra"
            };
            mockSupervisorRepository.Setup(r => r.FindById(supervisorId))
                .Returns(Task.FromResult<Supervisor>(t));

            var service = new SupervisorService(mockSupervisorRepository.Object, mockUnitOfWork.Object);

            // Act
            SupervisorResponse result = await service.GetByIdAsync(supervisorId);
            var success = result.Success;

            // Assert
            success.Should().Be(true);

        }

        private Mock<ISupervisorRepository> GetDefaultISupervisorRepositoryInstance()
        {
            return new Mock<ISupervisorRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
