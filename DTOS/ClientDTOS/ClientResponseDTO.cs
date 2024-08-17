namespace main_menu.DTOS.ClientDTOS
{
	public class ClientResponseDTO
	{
		public required ClientCategoryResponseDTO Category { get; set; }
		public required List<ClientProductResponseDTO> Products { get; set; }
	}
}