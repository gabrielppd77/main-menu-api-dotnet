using main_menu.Models;

namespace main_menu.DTOS.ClientDTOS
{
	public class ClientCategoryResponseDTO
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int Order { get; set; }

		public ClientCategoryResponseDTO(Category category)
		{
			Id = category.Id;
			Name = category.Name;
			Order = category.Order;
		}
	}
}