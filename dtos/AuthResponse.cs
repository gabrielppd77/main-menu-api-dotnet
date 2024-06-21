namespace main_menu.dtos
{
	public class AuthResponse
	{
		public Guid UserId { get; set; }
		public required string Token { get; set; }
	}
}