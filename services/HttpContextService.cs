using System.Security.Claims;

namespace main_menu.Services
{
	public class HttpContextService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public HttpContextService(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		internal Guid UserId
		{
			get
			{
				var userIdentifier = _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
				return Guid.TryParse(userIdentifier, out var userId) ? userId : Guid.Empty;
			}
		}
	}
}