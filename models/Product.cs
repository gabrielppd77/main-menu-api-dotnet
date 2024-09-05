namespace main_menu.Models
{
	public class Product
	{
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
		public Guid CategoryId { get; set; }
		public required string Name { get; set; }
		public required string Description { get; set; }
		public string? ImageUrl { get; set; }
		public int Order { get; set; }
		public decimal Price { get; set; }

		public virtual User? User { get; set; }
		public virtual Category? Category { get; set; }
	}
}