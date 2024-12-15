namespace main_menu.Models
{
	public class Product
	{
		public required Guid Id { get; set; }
		public required Guid CategoryId { get; set; }
		public required string Name { get; set; }
		public string? Description { get; set; }
		public string? UrlImage { get; set; }
		public required int Order { get; set; }
		public required decimal Price { get; set; }

		public virtual Category? Category { get; set; }
		public virtual List<OptionDivider>? OptionsDivider { get; set; }
	}
}