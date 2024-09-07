using System.ComponentModel.DataAnnotations;

namespace main_menu.DTOS.UserDTOS
{
	public class RegistrationRequestDTO
	{
		[EmailAddress]
		public required string Email { get; set; }
		public required string Password { get; set; }
		public required string CompanyName { get; set; }
		public required string UrlSite { get; set; }
	}
}