namespace main_menu.dtos
{
	public class ProductCreate
	{
		public required string Name { get; set; }
		public required string Description { get; set; }
		public required string ImageUrl { get; set; }
		public int Order { get; set; }
		public decimal Price { get; set; }
		public Guid CategoryId { get; set; }
	}
}