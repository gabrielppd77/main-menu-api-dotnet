
using main_menu.Models;

namespace main_menu.DTOS.ProductDTO
{
	public class ProductResponseDTO
	{
		public ProductResponseDTO(Product product)
		{
			Id = product.Id;
			Name = product.Name;
			Description = product.Description;
			ImageUrl = product.ImageUrl;
			Order = product.Order;
			Price = product.Price;
			CategoryName = product.Category?.Name ?? "";
		}

		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
		public int Order { get; set; }
		public decimal Price { get; set; }
		public string CategoryName { get; set; }
	}
}