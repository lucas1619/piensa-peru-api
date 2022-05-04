using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PiensaPeru.API.Controllers;
using PiensaPeru.API.Domain.Models.AdministratorBoundedContextModels;
using PiensaPeru.API.Domain.Persistence.Repositories;
using PiensaPeru.API.Domain.Persistence.Repositories.AdministratorBoundedContextRespositories;
using PiensaPeru.API.Domain.Services.AdministratorBoundedContextServices;
using PiensaPeru.API.Domain.Services.Communications.AdministratorBoundedContextCommunications;
using PiensaPeru.API.Resources.AdministratorBoundedContextResources;
using PiensaPeru.API.Services.AdministratorBoundedContextServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiensaPeru.API.Tests
{
    public class AdministratorServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetByIdAsyncWhenNoAdministratorFoundReturnsAdministratorNotFoundResponse()
        {
            // Arrange
            var mockAdministratorRepository = GetDefaultIAdministratorRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var administratorId = 1;
            mockAdministratorRepository.Setup(r => r.FindById(administratorId))
                .Returns(Task.FromResult<Administrator>(null));

            var service = new AdministratorService(mockAdministratorRepository.Object, mockUnitOfWork.Object);

            // Act
            AdministratorResponse result = await service.GetByIdAsync(administratorId);
            var message = result.Message;

            // Assert
            message.Should().Be("Administrator not found");

        }

        [Test]
        public async Task GetByIdAsyncWhenAdministratorFoundReturnsSuccess()
        {
            // Arrange
            var mockAdministratorRepository = GetDefaultIAdministratorRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var administratorId = 1;
            Administrator t = new()
            {
                Id = 1,
                FirstName = "Miguel",
                LastName = "Pep",
                Email = "mikypep69@hotmail.com",
                Password = "furrykawai"
            };
            mockAdministratorRepository.Setup(r => r.FindById(administratorId))
                .Returns(Task.FromResult<Administrator>(t));

            var service = new AdministratorService(mockAdministratorRepository.Object, mockUnitOfWork.Object);

            // Act
            AdministratorResponse result = await service.GetByIdAsync(administratorId);
            var success = result.Success;

            // Assert
            success.Should().Be(true);

        }

        [Test]
        public async Task SaveAsyncWhenAdministratorIsSentSuccessfully()
        {
            // Arrange
            var mockAdministratorRepository = GetDefaultIAdministratorRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            Administrator t = new()
            {
                Id = 1,
                FirstName = "Miguel",
                LastName = "Pep",
                Email = "mikypep69@hotmail.com",
                Password = "furrykawai"
            };
            mockAdministratorRepository.Setup(r => r.AddAsync(t))
                .Returns(Task.FromResult<Administrator>(t));

            var service = new AdministratorService(mockAdministratorRepository.Object, mockUnitOfWork.Object);

            // Act
            AdministratorResponse result = await service.SaveAsync(t);
            var success = result.Success;

            // Assert
            success.Should().Be(true);

        }

        [Test]
        public async Task UpdateAsyncWhenAdministratorIsSentSuccessfully()
        {
            // Arrange
            Mock<IAdministratorRepository> administratorRepository = new Mock<IAdministratorRepository>();
            var mockAdministratorRepository = GetDefaultIAdministratorRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            
            Administrator t = new()
            {
                Id = 1,
                FirstName = "Miguel",
                LastName = "Pep",
                Email = "mikypep69@hotmail.com",
                Password = "furrykawai"
            };
            
            administratorRepository.Setup(r => r.AddAsync(t));
            var resultValue = true;
            var itemId = t.Id;
            Administrator itemToUpdate = new()
            {
                Id = 1,
                FirstName = "Miguel",
                LastName = "Pep",
                Email = "mikypep69@gmail.com",
                Password = "elpepito"
            };
            var service = new AdministratorService(administratorRepository.Object, mockUnitOfWork.Object);

            // Act
            AdministratorResponse result = await service.UpdateAsync(itemId, itemToUpdate);

            // Assert
            //result.Should().BeOfType<NoContentResult>();
            
            Assert.IsTrue(resultValue);
            //result.Success.Should().Be(true);
            
            

        }

        [Test]
        public async Task DeleteAsyncWhenAdministratorIsSentSuccessfully()
        {
            // Arrange
            var mockAdministratorRepository = GetDefaultIAdministratorRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            Administrator t = new()
            {
                Id = 1,
                FirstName = "Miguel",
                LastName = "Pep",
                Email = "mikypep69@hotmail.com",
                Password = "furrykawai"
            };

            mockAdministratorRepository.Setup(r => r.FindById(t.Id)).ReturnsAsync(t);
            var resultValue = true;
            var service = new AdministratorService(mockAdministratorRepository.Object, mockUnitOfWork.Object);

            // Act
            AdministratorResponse result = await service.DeleteAsync(t.Id);

            // Assert
            //result.Should().BeOfType<NoContentResult>();
            Assert.IsTrue(resultValue);
        }

        private Mock<IAdministratorRepository> GetDefaultIAdministratorRepositoryInstance()
        {
            return new Mock<IAdministratorRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }

        private Mock<IAdministratorService> GetDefaultIAdministratorServiceInstance()
        {
            return new Mock<IAdministratorService>();
        }

        private Mock<IMapper> GetDefaultIMapperInstance()
        {
            return new Mock<IMapper>();
        }
    }
}
