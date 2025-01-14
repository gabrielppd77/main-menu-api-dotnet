using main_menu.DTOS.UserDTOS;
using main_menu.Models;
using main_menu.Utils;
using main_menu.Interfaces.Repositories;
using main_menu.Interfaces.Services;

namespace main_menu.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IHttpContextService _httpContextService;

		public UserService(IUserRepository userRepository, IHttpContextService httpContextService)
		{
			_userRepository = userRepository;
			_httpContextService = httpContextService;
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

			var company = new Company
			{
				Id = Guid.NewGuid(),
				UserId = user.Id,
				Name = request.CompanyName,
				Path = request.CompanyName.ToLower().Replace(" ", "-")
			};

			await _userRepository.AddUser(user);
			await _userRepository.AddCompany(company);

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

		public async Task RemoveAccount(string password)
		{
			var user = await _userRepository.GetById(_httpContextService.UserId);

			if (user == null)
			{
				throw new BadHttpRequestException("Não foi possível encontrar o usuário.");
			}

			if (!PasswordHasher.VerifyPassword(password, user.Password))
			{
				throw new BadHttpRequestException("Não foi possível prosseguir, credenciais incorretas.");
			}

			_userRepository.RemoveUser(user);
			await _userRepository.SaveChanges();
		}
	}
}