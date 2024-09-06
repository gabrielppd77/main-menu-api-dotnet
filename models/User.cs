namespace main_menu.Models
{
	public class User
	{
		public Guid Id { get; set; }
		public required string Email { get; set; }
		public required string Password { get; set; }

		public virtual Company? Company { get; set; }
	}
}