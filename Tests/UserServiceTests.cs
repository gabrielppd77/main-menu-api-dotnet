using main_menu.DTOS.UserDTOS;
using main_menu.Interfaces.Repositories;
using main_menu.Interfaces.Services;
using main_menu.Models;
using main_menu.Services;
using Moq;
using Xunit;

namespace main_menu.Tests
{
	public class UserServiceTests
	{
		private readonly Mock<IUserRepository> _mockRepository;
		private readonly Mock<IHttpContextService> _mockHttpContextService;
		private readonly UserService _service;

		public UserServiceTests()
		{
			_mockRepository = new Mock<IUserRepository>();
			_mockHttpContextService = new Mock<IHttpContextService>();
			_service = new UserService(_mockRepository.Object, _mockHttpContextService.Object);
		}

		[Fact]
		public async Task CreateUserAsync_ShouldThrowException_WhenEmailAlreadyExists()
		{
			// Arrange
			var userRequest = new RegistrationRequestDTO()
			{
				CompanyName = "CompanyName",
				Email = "email@email.com",
				Password = "1234"
			};

			_mockRepository.Setup(repo => repo.FindByEmail(userRequest.Email)).ReturnsAsync(new User()
			{
				Id = Guid.Empty,
				Email = userRequest.Email,
				Password = userRequest.Password
			});

			// Act & Assert
			await Assert.ThrowsAsync<BadHttpRequestException>(() => _service.CreateUser(userRequest));
			_mockRepository.Verify(repo => repo.FindByEmail(userRequest.Email), Times.Once);
			_mockRepository.VerifyNoOtherCalls();
		}

		[Fact]
		public async Task CreateUser_ShouldCreateUser_WhenEmailDoesNotExist()
		{
			// Arrange
			var userRequest = new RegistrationRequestDTO
			{
				CompanyName = "CompanyName",
				Email = "newemail@email.com",
				Password = "1234"
			};

			_mockRepository.Setup(repo => repo.FindByEmail(userRequest.Email)).ReturnsAsync((User?)null);
			_mockRepository.Setup(repo => repo.AddUser(It.IsAny<User>()));
			_mockRepository.Setup(repo => repo.AddCompany(It.IsAny<Company>()));
			_mockRepository.Setup(repo => repo.SaveChanges());

			// Act
			var result = await _service.CreateUser(userRequest);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(userRequest.Email, result.Email);
			Assert.NotEqual(userRequest.Password, result.Password);

			_mockRepository.Verify(repo => repo.FindByEmail(userRequest.Email), Times.Once);
			_mockRepository.Verify(repo => repo.AddUser(It.IsAny<User>()), Times.Once);
			_mockRepository.Verify(repo => repo.AddCompany(It.IsAny<Company>()), Times.Once);
			_mockRepository.Verify(repo => repo.SaveChanges(), Times.Once);

			_mockRepository.VerifyNoOtherCalls();
		}
	}
}