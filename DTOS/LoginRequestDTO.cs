using System.ComponentModel.DataAnnotations;

namespace main_menu.DTOS
{
	public class LoginRequestDTO
	{
		[Required]
		[EmailAddress]
		public required string Email { get; set; }

		[Required]
		public required string Password { get; set; }
	}
}