namespace main_menu.Models
{
	public class Product
	{
		public Guid Id { get; set; }
		public Guid CompanyId { get; set; }
		public Guid CategoryId { get; set; }
		public required string Name { get; set; }
		public required string Description { get; set; }
		public string? UrlImage { get; set; }
		public int Order { get; set; }
		public decimal Price { get; set; }

		public Company? Company { get; set; }
		public Category? Category { get; set; }
	}
}