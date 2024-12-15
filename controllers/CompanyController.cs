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

		[HttpPut()]
		public async Task Update(CompanyUpdateDTO request)
		{
			await _service.Update(request);
		}

		[HttpPut("update-image")]
		public async Task UpdateImage(IFormFile file)
		{
			await _service.UpdateImage(file);
		}

		[HttpGet("get-qr-code")]
		public async Task<IActionResult> GetQRCode()
		{
			var qrCode = await _service.GetQRCode();
			return File(qrCode, "image/png", "qrcode.png");
		}
	}
}