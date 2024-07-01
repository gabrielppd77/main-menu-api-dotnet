namespace main_menu.models
{
	public class Category
	{
		public Guid Id { get; set; }
		public required string Name { get; set; }
		public int Order { get; set; }
	}
}