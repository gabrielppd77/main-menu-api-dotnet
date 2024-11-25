using main_menu.DTOS.CompanyDTOS;
using main_menu.Services;
using Microsoft.AspNetCore.Mvc;

namespace main_menu.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CompanyController : ControllerBase
	{
		private readonly CompanyService _service;

		public CompanyController(CompanyService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<CompanyResponseDTO> GetCompany()
		{
			return await _service.GetCompany();
		}

		[HttpPut("{id}")]
		public async Task Update(Guid id, CompanyUpdateDTO request)
		{
			await _service.Update(id, request);
		}

		[HttpPut("update-image/{id}")]
		public async Task UpdateImage(Guid id, IFormFile file)
		{
			await _service.UpdateImage(id, file);
		}

		[HttpGet("get-qr-code")]
		public async Task<IActionResult> GetQRCode()
		{
			var qrCode = await _service.GetQRCode();
			return File(qrCode, "image/png", "qrcode.png");
		}
	}
}