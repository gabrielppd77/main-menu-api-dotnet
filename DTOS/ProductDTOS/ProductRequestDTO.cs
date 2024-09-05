namespace main_menu.DTOS.ProductDTO
{
	public class ProductRequestDTO
	{
		public required string Name { get; set; }
		public required string Description { get; set; }
		public string? ImageUrl { get; set; }
		public int Order { get; set; }
		public decimal Price { get; set; }
		public Guid CategoryId { get; set; }
	}
}