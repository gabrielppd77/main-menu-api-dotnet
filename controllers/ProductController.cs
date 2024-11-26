using main_menu.DTOS.ProductDTO;
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

		[HttpGet()]
		public async Task<List<ProductResponseTableDTO>> GetAll()
		{
			return await _service.GetAll();
		}

		[HttpPost()]
		public async Task Create(ProductRequestDTO request)
		{
			await _service.Create(request);
		}

		[HttpPut()]
		public async Task Update(Guid id, ProductRequestDTO request)
		{
			await _service.Update(id, request);
		}

		[HttpDelete()]
		public async Task Remove(Guid id)
		{
			await _service.Remove(id);
		}

		[HttpGet("{id}")]
		public async Task<ProductResponseFormDTO> GetById(Guid id)
		{
			return await _service.GetById(id);
		}

		[HttpPut("update-image")]
		public async Task UpdateImage(Guid id, IFormFile file)
		{
			await _service.UpdateImage(id, file);
		}
	}
}