
using main_menu.Models;

namespace main_menu.DTOS.ProductDTO
{
	public class ProductResponseDTO
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string? UrlImage { get; set; }
		public int Order { get; set; }
		public decimal Price { get; set; }
		public Guid CategoryId { get; set; }
		public string CategoryName { get; set; }

		public ProductResponseDTO(Product product)
		{
			Id = product.Id;
			Name = product.Name;
			Description = product.Description;
			UrlImage = product.UrlImage;
			Order = product.Order;
			Price = product.Price;
			CategoryId = product.Category?.Id ?? default;
			CategoryName = product.Category?.Name ?? "";
		}
	}
}