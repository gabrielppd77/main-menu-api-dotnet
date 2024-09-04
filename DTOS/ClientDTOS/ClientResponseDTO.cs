using main_menu.Models;

namespace main_menu.DTOS.ClientDTOS
{
	public class ClientResponseDTO : ClientCategoryResponseDTO
	{
		public ClientResponseDTO(Category category) : base(category)
		{
		}

		public required List<ClientProductResponseDTO> Products { get; set; }
	}
}