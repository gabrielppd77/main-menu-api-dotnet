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

		[HttpGet]
		public async Task<ClientResponseDTO> GetMainData(string urlSite)
		{
			return await _service.GetMainData(urlSite);
		}
	}
}