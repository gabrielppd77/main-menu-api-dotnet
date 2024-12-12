namespace main_menu.Models
{
	public class Option
	{
		public Guid Id { get; set; }
		public Guid OptionDividerId { get; set; }
		public required string Title { get; set; }
		public string? Subtitle { get; set; }
		public decimal? Price { get; set; }

		public virtual OptionDivider? OptionDivider { get; set; }
	}
}