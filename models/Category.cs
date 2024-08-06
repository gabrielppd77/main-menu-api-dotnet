namespace main_menu.Models
{
	public class Category
	{
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
		public required string Name { get; set; }
		public int Order { get; set; }

		public virtual User? User { get; set; }
	}
}