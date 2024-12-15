using main_menu.Database.Repositories;
using main_menu.DTOS.CategoryDTOS;
using main_menu.Models;

namespace main_menu.Services
{
	public class CategoryService
	{
		private readonly CategoryRepository _repository;
		private readonly HttpContextService _httpContextService;

		public CategoryService(CategoryRepository repository, HttpContextService httpContextService)
		{
			_repository = repository;
			_httpContextService = httpContextService;
		}

		internal async Task<List<CategoryResponseDTO>> GetAll()
		{
			var categories = await _repository.GetAllByUser(_httpContextService.UserId);
			return categories.Select(x => new CategoryResponseDTO()
			{
				Id = x.Id,
				Name = x.Name,
				Order = x.Order
			}).ToList();
		}

		internal async Task Create(CategoryRequestDTO request)
		{
			var companyId = await _repository.GetCompanyIdByUser(_httpContextService.UserId);

			if (companyId == default)
			{
				throw new BadHttpRequestException("Não foi possível encontrar a loja.");
			}

			var category = new Category()
			{
				Id = Guid.NewGuid(),
				CompanyId = companyId,
				Name = request.Name,
				Order = request.Order,
			};
			await _repository.AddCategory(category);
			await _repository.SaveChanges();
		}

		internal async Task Update(Guid id, CategoryRequestDTO request)
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