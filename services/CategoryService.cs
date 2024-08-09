using main_menu.Contexts;
using main_menu.Database.repositories;
using main_menu.DTOS;
using main_menu.Models;

namespace main_menu.Services
{
	public class CategoryService
	{
		private readonly CategoryRepository _repository;
		private readonly UserContext _userContext;

		public CategoryService(CategoryRepository repository, UserContext userContext)
		{
			_repository = repository;
			_userContext = userContext;
		}

		internal async Task<List<CategoryResponseDTO>> GetAll()
		{
			var categories = await _repository.GetAllByUser(_userContext.UserId);
			return categories
				.Select(x => new CategoryResponseDTO()
				{
					Id = x.Id,
					Name = x.Name,
					Order = x.Order,
				})
				.ToList();
		}

		internal async Task Create(CategoryCreateDTO request)
		{
			var category = new Category()
			{
				Id = Guid.NewGuid(),
				UserId = _userContext.UserId,
				Name = request.Name,
				Order = request.Order
			};
			await _repository.AddCategory(category);
			await _repository.SaveChanges();
		}

		internal async Task Update(Guid id, CategoryUpdateDTO request)
		{
			var category = await _repository.GetById(id);

			if (category == null)
			{
				throw new BadHttpRequestException("Não foi possível encontrar a categoria.");
			}

			category.Name = request.Name;
			category.Order = request.Order;

			await _repository.SaveChanges();
		}

		internal async Task Remove(Guid id)
		{
			var category = await _repository.GetById(id);

			if (category == null)
			{
				throw new BadHttpRequestException("Não foi possível encontrar a categoria.");
			}

			_repository.RemoveCategory(category);

			await _repository.SaveChanges();
		}
	}
}