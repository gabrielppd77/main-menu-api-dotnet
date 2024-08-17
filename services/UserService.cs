using main_menu.DTOS.UserDTOS;
using main_menu.Models;
using main_menu.Utils;
using main_menu.Database.Repositories;

namespace main_menu.Services
{
	public class UserService
	{
		private readonly UserRepository _userRepository;

		public UserService(UserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<User> CreateUser(RegistrationRequestDTO request)
		{
			var userFinded = await _userRepository.FindByEmail(request.Email);

			if (userFinded != null)
			{
				throw new BadHttpRequestException("Não foi possível prosseguir, encontramos um usuário já cadastrado com o email informado.");
			}

			var hashedPassword = PasswordHasher.HashPassword(request.Password);

			var user = new User
			{
				Id = Guid.NewGuid(),
				Email = request.Email,
				Password = hashedPassword,
			};

			await _userRepository.AddUser(user);

			await _userRepository.SaveChanges();

			return user;
		}


		public async Task<User> AuthUser(LoginRequestDTO request)
		{
			var userFinded = await _userRepository.FindByEmail(request.Email);

			if (userFinded == null)
			{
				throw new BadHttpRequestException("Não foi possível prosseguir, credenciais incorretas.");
			}

			if (!PasswordHasher.VerifyPassword(request.Password, userFinded.Password))
			{
				throw new BadHttpRequestException("Não foi possível prosseguir, credenciais incorretas.");
			}

			return userFinded;
		}
	}
}