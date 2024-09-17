namespace main_menu.DTOS.CategoryDTOS
{
	public class CategoryResponseDTO
	{
		public required Guid Id { get; set; }
		public required string Name { get; set; }
		public required int Order { get; set; }
	}
}