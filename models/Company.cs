namespace main_menu.Models
{
	public class Company
	{
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
		public required string Name { get; set; }
		public required string UrlSite { get; set; }

		public virtual User? User { get; set; }
		public ICollection<Category>? Categories { get; set; }
		public ICollection<Product>? Products { get; set; }
	}
}