using main_menu.DTOS.ClientDTOS;
using main_menu.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace main_menu.Controllers
{
	[AllowAnonymous]
	[ApiController]
	[Route("api/[controller]")]
	public class ClientController : ControllerBase
	{
		private readonly ClientService _service;

		public ClientController(ClientService service)
		{
			_service = service;
		}

		[HttpGet("get-all-companies")]
		public async Task<List<ClientResponseDTO>> GetAllCompanies()
		{
			return await _service.GetAllCompanies();
		}

		[HttpGet("get-company-data")]
		public async Task<ClientResponseDTO> GetCompanyData(string companyPath, string? query)
		{
			return await _service.GetCompanyData(companyPath, query);
		}
	}
}