using main_menu.database.repositories;
using main_menu.dtos;
using main_menu.models;

namespace main_menu.services
{
	public class CategoryService
	{
		private readonly CategoryRepository _repository;

		public CategoryService(CategoryRepository repository)
		{
			_repository = repository;
		}

		internal async Task Create(CategoryCreate request)
		{
			var category = new Category()
			{
				Id = Guid.NewGuid(),
				Name = request.Name,
				Order = request.Order
			};
			await _repository.AddCategory(category);
			await _repository.SaveChanges();
		}

		internal async Task Remove(Guid id)
		{
			var category = await _repository.GetById(id);

			if (category == null)
			{
				throw new BadHttpRequestException("Não foi possível encontrar a categoria");
			}

			_repository.RemoveCategory(category);

			await _repository.SaveChanges();
		}

		internal async Task Update(Guid id, CategoryUpdate request)
		{
			var category = await _repository.GetById(id);

			if (category == null)
			{
				throw new BadHttpRequestException("Não foi possível encontrar a categoria");
			}

			category.Name = request.Name;
			category.Order = request.Order;

			await _repository.SaveChanges();
		}
	}
}