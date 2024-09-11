using main_menu.Models;

namespace main_menu.DTOS.CategoryDTOS
{
	public class CategoryResponseDTO
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int Order { get; set; }

		public CategoryResponseDTO(Category category)
		{
			Id = category.Id;
			Name = category.Name;
			Order = category.Order;
		}
	}
}