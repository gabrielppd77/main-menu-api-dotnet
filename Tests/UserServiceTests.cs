using main_menu.Interfaces.Repositories;
using main_menu.Models;
using main_menu.Services;
using Moq;
using Xunit;

namespace main_menu.Tests
{
	public class UserServiceTests
	{
		private readonly Mock<IUserRepository> _mockRepository;
		private readonly Mock<HttpContextService> _mockHttpContextService;
		private readonly UserService _service;

		public UserServiceTests()
		{
			_mockRepository = new Mock<IUserRepository>();
			_mockHttpContextService = new Mock<HttpContextService>();

			_service = new UserService(_mockRepository.Object, _mockHttpContextService.Object);
		}

		[Fact]
		public async Task CreateUserAsync_ShouldThrowException_WhenFindUserEmailAlreadyRegister()
		{
			// Arrange
			var userRequest = new DTOS.UserDTOS.RegistrationRequestDTO()
			{
				CompanyName = "CompanyName",
				Email = "email@email.com",
				Password = "1234"
			};
			_mockRepository.Setup(repo => repo.FindByEmail(userRequest.Email)).ReturnsAsync((User?)null);

			// Act & Assert
			await Assert.ThrowsAsync<BadHttpRequestException>(() => _service.CreateUser(userRequest));
			_mockRepository.Verify(repo => repo.FindByEmail(userRequest.Email), Times.Once);
		}
	}
}