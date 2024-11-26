namespace main_menu.DTOS.ProductDTO
{
	public class ProductResponseTableDTO
	{
		public required Guid Id { get; set; }
		public required string Name { get; set; }
		public string? Description { get; set; }
		public required int Order { get; set; }
		public required decimal Price { get; set; }
		public required string CategoryName { get; set; }
	}
}