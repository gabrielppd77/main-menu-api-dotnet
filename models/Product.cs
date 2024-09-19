namespace main_menu.Models
{
	public class Product
	{
		public required Guid Id { get; set; }
		public required Guid CompanyId { get; set; }
		public required Guid CategoryId { get; set; }
		public required string Name { get; set; }
		public string? Description { get; set; }
		public string? UrlImage { get; set; }
		public required int Order { get; set; }
		public required decimal Price { get; set; }

		public virtual Company? Company { get; set; }
		public virtual Category? Category { get; set; }
	}
}