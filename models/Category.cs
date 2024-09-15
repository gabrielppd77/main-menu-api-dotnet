namespace main_menu.Models
{
	public class Category
	{
		public required Guid Id { get; set; }
		public required Guid CompanyId { get; set; }
		public required string Name { get; set; }
		public required int Order { get; set; }

		public virtual Company? Company { get; set; }
		public virtual List<Product>? Products { get; set; }
	}
}