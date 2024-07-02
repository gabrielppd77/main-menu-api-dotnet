using main_menu.dtos;
using main_menu.services;
using Microsoft.AspNetCore.Mvc;

namespace main_menu.controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController : ControllerBase
	{
		private readonly ProductService _service;

		public ProductController(ProductService service)
		{
			_service = service;
		}

		[HttpPost]
		public async Task Create(ProductCreate request)
		{
			await _service.Create(request);
		}

		[HttpDelete("{id}")]
		public async Task Remove(Guid id)
		{
			await _service.Remove(id);
		}

		[HttpPut("{id}")]
		public async Task Update(Guid id, ProductUpdate request)
		{
			await _service.Update(id, request);
		}
	}
}