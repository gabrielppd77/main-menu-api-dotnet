using System.Security.Claims;
using main_menu.Interfaces.Services;

namespace main_menu.Services
{
	public class HttpContextService : IHttpContextService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public HttpContextService(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public new Guid UserId
		{
			get
			{
				var userIdentifier = _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
				return Guid.TryParse(userIdentifier, out var userId) ? userId : Guid.Empty;
			}
		}
	}
}