namespace main_menu.DTOS
{
	public class CategoryResponseDTO
	{
		public Guid Id { get; set; }
		public required string Name { get; set; }
		public int Order { get; set; }
	}
}