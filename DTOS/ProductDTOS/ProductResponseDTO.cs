
using main_menu.Models;

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

		public ProductResponseDTO(Product product)
		{
			Id = product.Id;
			Name = product.Name;
			Description = product.Description;
			UrlImage = product.UrlImage;
			Order = product.Order;
			Price = product.Price;
			// CategoryId = product.Category?.Id ?? default;
			// CategoryName = product.Category?.Name ?? "";
			CategoryName = "";
		}
	}
}