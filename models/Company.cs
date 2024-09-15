namespace main_menu.Models
{
	public class Company
	{
		public required Guid Id { get; set; }
		public required Guid UserId { get; set; }
		public required string Name { get; set; }
		public required string UrlSite { get; set; }

		public virtual User? User { get; set; }
		public virtual List<Category>? Categories { get; set; }
		public virtual List<Product>? Products { get; set; }
	}
}