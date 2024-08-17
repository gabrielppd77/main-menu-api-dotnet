
namespace main_menu.DTOS.ProductDTO
{
	public class ProductResponseDTO
	{
		public Guid Id { get; set; }
		public required string Name { get; set; }
		public required string Description { get; set; }
		public required string ImageUrl { get; set; }
		public int Order { get; set; }
		public decimal Price { get; set; }
		public required string CategoryName { get; set; }
	}
}