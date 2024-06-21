using System.ComponentModel.DataAnnotations;

namespace main_menu.dtos
{
	public class RegistrationRequest
	{
		[Required]
		[EmailAddress]
		public required string Email { get; set; }

		[Required]
		public required string Password { get; set; }
	}
}