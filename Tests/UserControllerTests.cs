namespace Tests
{
    using Api.Controllers;
    using Application;
    using Application.Ports;
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
    using Moq;

    // Tests/UserControllerTests.cs
    using System;
    using Xunit;

    public class UserControllerTests
    {
        [Fact]
        public void CreateUser_ValidRequest_ShouldReturnOk()
        {
            // Arrange
            var createUserUseCaseMock = new Mock<ICreateUserUseCase>();
            var controller = new UserController(createUserUseCaseMock.Object);
            var createUserRequest = new CreateUserRequest { Name = "John Doe" };

            // Act
            var result = controller.CreateUser(createUserRequest) as OkObjectResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
            result.Value.Should().NotBeNull();
            result.Value.Should().BeOfType(typeof(CreateUserResponse));
        }

        [Fact]
        public void CreateUser_InvalidRequest_ShouldReturnBadRequest()
        {
            // Arrange
            var createUserUseCaseMock = new Mock<ICreateUserUseCase>();
            var controller = new UserController(createUserUseCaseMock.Object);
            var createUserRequest = new CreateUserRequest(); // Empty request

            // Act
            var result = controller.CreateUser(createUserRequest) as BadRequestObjectResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(400);
            result.Value.Should().NotBeNull();
            result.Value.Should().Be("User name is required.");
        }

        [Fact]
        public void CreateUser_UseCaseThrowsException_ShouldReturnInternalServerError()
        {
            // Arrange
            var createUserUseCaseMock = new Mock<ICreateUserUseCase>();
            createUserUseCaseMock.Setup(useCase => useCase.Execute(It.IsAny<CreateUserRequest>()))
                .Throws(new Exception("Simulated use case exception"));
            var controller = new UserController(createUserUseCaseMock.Object);
            var createUserRequest = new CreateUserRequest { Name = "John Doe" };

            // Act
            var result = controller.CreateUser(createUserRequest) as ObjectResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(500);
            result.Value.Should().NotBeNull();
            result.Value.Should().Be("An error occurred while creating the user: Simulated use case exception");
        }
    }
}