using main_menu.DTOS;
using main_menu.Services;
using Microsoft.AspNetCore.Mvc;

namespace main_menu.Controllers
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
		public async Task Create(ProductCreateDTO request)
		{
			await _service.Create(request);
		}

		[HttpPut("{id}")]
		public async Task Update(Guid id, ProductUpdateDTO request)
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