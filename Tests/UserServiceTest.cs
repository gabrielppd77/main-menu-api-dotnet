using main_menu.Database.repositories;
using main_menu.DTOS.UserDTOS;
using main_menu.Services;
using Moq;
using Xunit;

namespace main_menu.Tests
{
	public class UserServiceTest
	{
		[Fact]
		public async Task CreateUser()
		{
			var repository = new Mock<UserRepository>();
			var service = new UserService(repository.Object);

			var data = new RegistrationRequestDTO()
			{
				Email = "fake-email@email.com",
				Password = "123456",
			};

			var newUser = await service.CreateUser(data);

			Assert.NotNull(newUser);
			Assert.NotEqual(data.Password, newUser.Password);

			//user esteje no banco de dados
			//user seje retornado
		}
	}
}