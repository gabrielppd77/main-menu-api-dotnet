using Microsoft.AspNetCore.Mvc;

using main_menu.dtos;
using main_menu.services;

namespace main_menu.controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		private readonly UserService _userService;
		private readonly TokenService _tokenService;

		public UserController(UserService userService, TokenService tokenService)
		{
			_userService = userService;
			_tokenService = tokenService;
		}

		[HttpPost("register")]
		public async Task<AuthResponse> Register(RegistrationRequest request)
		{
			var user = await _userService.CreateUser(request);
			var token = _tokenService.CreateToken(user.Id);
			return new AuthResponse()
			{
				UserId = user.Id,
				Token = token
			};
		}

		[HttpPost("login")]
		public async Task<AuthResponse> Login(LoginRequest request)
		{
			var user = await _userService.AuthUser(request);
			var token = _tokenService.CreateToken(user.Id);
			return new AuthResponse()
			{
				UserId = user.Id,
				Token = token
			};
		}
	}
}