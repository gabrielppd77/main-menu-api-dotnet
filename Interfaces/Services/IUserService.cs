using main_menu.DTOS.UserDTOS;
using main_menu.Models;

namespace main_menu.Interfaces.Services
{
	public interface IUserService
	{
		Task<User> CreateUser(RegistrationRequestDTO request);
		Task<User> AuthUser(LoginRequestDTO request);
		Task RemoveAccount(string password);
	}
}