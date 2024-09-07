using System.ComponentModel.DataAnnotations;

namespace main_menu.DTOS.UserDTOS
{
	public class LoginRequestDTO
	{
		[EmailAddress]
		public required string Email { get; set; }
		public required string Password { get; set; }
	}
}