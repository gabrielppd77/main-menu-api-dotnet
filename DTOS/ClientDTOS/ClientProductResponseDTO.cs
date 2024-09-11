using main_menu.Models;

namespace main_menu.DTOS.ClientDTOS
{
	public class ClientProductResponseDTO
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string? UrlImage { get; set; }
		public int Order { get; set; }
		public decimal Price { get; set; }

		public ClientProductResponseDTO(Product product)
		{
			Id = product.Id;
			Name = product.Name;
			Description = product.Description;
			UrlImage = product.UrlImage;
			Order = product.Order;
			Price = product.Price;
		}
	}
}