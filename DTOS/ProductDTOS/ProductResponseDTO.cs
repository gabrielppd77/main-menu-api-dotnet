namespace main_menu.DTOS.ProductDTO
{
	public class ProductResponseDTO
	{
		public required Guid Id { get; set; }
		public required string Name { get; set; }
		public required string Description { get; set; }
		public string? UrlImage { get; set; }
		public required int Order { get; set; }
		public required decimal Price { get; set; }
		public required Guid CategoryId { get; set; }
		public required string CategoryName { get; set; }
	}
}