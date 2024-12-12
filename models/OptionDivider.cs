namespace main_menu.Models
{
	public class OptionDivider
	{
		public Guid Id { get; set; }
		public Guid ProductId { get; set; }
		public required string Title { get; set; }
		public int Quantity { get; set; } = 1;
		public bool IsRequired { get; set; }

		public virtual Product? Product { get; set; }
	}
}