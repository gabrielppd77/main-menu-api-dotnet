namespace main_menu.Models
{
	public class Category
	{
		public Guid Id { get; set; }
		public Guid CompanyId { get; set; }
		public required string Name { get; set; }
		public int Order { get; set; }

		public Company? Company { get; set; }
		public ICollection<Product>? Products { get; set; }
	}
}