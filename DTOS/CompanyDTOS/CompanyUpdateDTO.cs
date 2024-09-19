namespace main_menu.DTOS.CompanyDTOS
{
	public class CompanyUpdateDTO
	{
		public required string Name { get; set; }
		public string? Description { get; set; }
		public string? UrlImage { get; set; }
	}
}