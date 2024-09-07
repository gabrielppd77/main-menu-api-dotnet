using main_menu.Models;

namespace main_menu.DTOS.ClientDTOS
{
	public class ClientCategoryResponseDTO
	{
		public required Guid Id { get; set; }
		public required string Name { get; set; }
		public required int Order { get; set; }

		public ClientCategoryResponseDTO(Category category)
		{
			Id = category.Id;
			Name = category.Name;
			Order = category.Order;
		}
	}
}