namespace main_menu.DTOS.ClientDTOS
{
	public class ClientProductResponseDTO
	{
		public Guid Id { get; set; }
		public required string Name { get; set; }
		public required string Description { get; set; }
		public string? UrlImage { get; set; }
		public int Order { get; set; }
		public decimal Price { get; set; }
	}
}