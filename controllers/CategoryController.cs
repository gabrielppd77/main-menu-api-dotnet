using main_menu.dtos;
using main_menu.services;
using Microsoft.AspNetCore.Mvc;

namespace main_menu.controllers
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

		[HttpPost]
		public async Task Create(CategoryCreate request)
		{
			await _service.Create(request);
		}

		[HttpDelete("{id}")]
		public async Task Remove(Guid id)
		{
			await _service.Remove(id);
		}

		[HttpPut("{id}")]
		public async Task Update(Guid id, CategoryUpdate request)
		{
			await _service.Update(id, request);
		}
	}
}