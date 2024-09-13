namespace main_menu.DTOS.ClientDTOS
{
	public class ClientCategoryResponseDTO
	{
		public Guid Id { get; set; }
		public required string Name { get; set; }
		public int Order { get; set; }
		public required List<ClientProductResponseDTO> Products { get; set; }
	}
}