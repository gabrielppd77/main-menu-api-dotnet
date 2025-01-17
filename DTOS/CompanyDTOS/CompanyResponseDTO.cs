namespace main_menu.DTOS.CompanyDTOS
{
	public class CompanyResponseDTO
	{
		public required Guid Id { get; set; }
		public required string Name { get; set; }
		public required string Path { get; set; }
		public string? Description { get; set; }
		public string? UrlImage { get; set; }
	}
}