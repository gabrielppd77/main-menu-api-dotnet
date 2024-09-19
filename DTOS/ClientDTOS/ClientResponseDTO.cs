namespace main_menu.DTOS.ClientDTOS
{
	public class ClientResponseDTO
	{
		public required Guid CompanyId { get; set; }
		public required string CompanyName { get; set; }
		public string? CompanyDescription { get; set; }
		public string? CompanyUrlImage { get; set; }
		public required List<ClientCategoryResponseDTO> Categories { get; set; }
	}
}