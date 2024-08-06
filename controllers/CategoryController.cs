using main_menu.DTOS;
using main_menu.Services;
using Microsoft.AspNetCore.Mvc;

namespace main_menu.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CategoryController : ControllerBase
	{
		private readonly CategoryService _service;

		public CategoryController(CategoryService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<List<CategoryResponseDTO>> GetAll()
		{
			return await _service.GetAll();
		}

		[HttpPost]
		public async Task Create(CategoryCreateDTO request)
		{
			await _service.Create(request);
		}

		[HttpPut("{id}")]
		public async Task Update(Guid id, CategoryUpdateDTO request)
		{
			await _service.Update(id, request);
		}

		[HttpDelete("{id}")]
		public async Task Remove(Guid id)
		{
			await _service.Remove(id);
		}
	}
}