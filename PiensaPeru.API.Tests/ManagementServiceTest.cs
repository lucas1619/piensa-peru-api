using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PiensaPeru.API.Domain.Models.AdministratorBoundedContextModels;
using PiensaPeru.API.Domain.Persistence.Repositories;
using PiensaPeru.API.Domain.Persistence.Repositories.AdministratorBoundedContextRespositories;
using PiensaPeru.API.Domain.Services.Communications.AdministratorBoundedContextCommunications;
using PiensaPeru.API.Services.AdministratorBoundedContextServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiensaPeru.API.Tests
{
    public class ManagementServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetByIdAsyncWhenNoManagementFoundReturnsManagementNotFoundResponse()
        {
            // Arrange
            var mockManagementRepository = GetDefaultIManagementRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var managementId = 1;
            mockManagementRepository.Setup(r => r.FindById(managementId))
                .Returns(Task.FromResult<Management>(null));

            var service = new ManagementService(mockManagementRepository.Object, mockUnitOfWork.Object);

            // Act
            ManagementResponse result = await service.GetByIdAsync(managementId);
            var message = result.Message;

            // Assert
            message.Should().Be("Management not found");

        }

        [Test]
        public async Task GetByIdAsyncWhenManagementFoundReturnsSuccess()
        {
            // Arrange
            var mockManagementRepository = GetDefaultIManagementRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var managementId = 1;
            Management t = new()
            {
                Id = 1,
                ManagementType = "Type 1",
                AdministratorId = 1
            };
            mockManagementRepository.Setup(r => r.FindById(managementId))
                .Returns(Task.FromResult<Management>(t));

            var service = new ManagementService(mockManagementRepository.Object, mockUnitOfWork.Object);

            // Act
            ManagementResponse result = await service.GetByIdAsync(managementId);
            var success = result.Success;

            // Assert
            success.Should().Be(true);

        }

        [Test]
        public async Task SaveAsyncWhenManagementIsSentSuccessfully()
        {
            // Arrange
            var mockManagementRepository = GetDefaultIManagementRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            Management t = new()
            {
                Id = 1,
                ManagementType = "Type 1",
                AdministratorId = 1,
                ContentId = 1
            };
            mockManagementRepository.Setup(r => r.AddAsync(t))
                .Returns(Task.FromResult<Management>(t));

            var service = new ManagementService(mockManagementRepository.Object, mockUnitOfWork.Object);

            // Act
            ManagementResponse result = await service.SaveAsync(1, 1, t);
            var success = result.Success;

            // Assert
            success.Should().Be(true);

        }

        [Test]
        public async Task UpdateAsyncWhenManagementIsSentSuccessfully()
        {
            // Arrange
            Management t = new()
            {
                Id = 1,
                ManagementType = "Type 1",
                AdministratorId = 1,
                ContentId = 1
            };
            var mockManagementRepository = GetDefaultIManagementRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            
            mockManagementRepository.Setup(r => r.FindById(t.Id)).ReturnsAsync(t);

            var itemId = t.Id;
            var itemToUpdate = new Management()
            {
                Id = 1,
                ManagementType = "Type 2",
                AdministratorId = 1,
                ContentId = 1
            };

            var service = new ManagementService(mockManagementRepository.Object, mockUnitOfWork.Object);

            // Act
            ManagementResponse result = await service.UpdateAsync(itemId, itemToUpdate);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }

        [Test]
        public async Task DeleteAsyncWhenManagementIsSentSuccessfully()
        {
            // Arrange
            var mockManagementRepository = GetDefaultIManagementRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            Management t = new()
            {
                Id = 1,
                ManagementType = "Type 1",
                AdministratorId = 1,
                ContentId = 1
            };
            mockManagementRepository.Setup(r => r.Remove(t));

            var service = new ManagementService(mockManagementRepository.Object, mockUnitOfWork.Object);

            // Act
            ManagementResponse result = await service.DeleteAsync(t.Id);
            var success = result.Success;

            // Assert
            success.Should().Be(true);

        }

        private Mock<IManagementRepository> GetDefaultIManagementRepositoryInstance()
        {
            return new Mock<IManagementRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
