namespace main_menu.Models
{
	public class Option
	{
		public Guid Id { get; set; }
		public required string Title { get; set; }
		public int Order { get; set; }
		public string? Subtitle { get; set; }
		public decimal? Price { get; set; }
		public string? UrlImage { get; set; }
	}
}