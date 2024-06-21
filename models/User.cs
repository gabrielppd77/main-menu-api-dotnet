namespace main_menu.models
{
	public class User
	{
		public Guid Id { get; set; }
		public required string Email { get; set; }
		public required string Password { get; set; }
	}
}