using main_menu.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace main_menu.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProjectController : ControllerBase
	{
		private readonly ProjectService _service;
		public ProjectController(ProjectService service)
		{
			_service = service;
		}

		[AllowAnonymous]
		[HttpPut("run-migrations")]
		public async Task RunMigrations(string password)
		{
			await _service.RunMigrations(password);
		}
	}
}