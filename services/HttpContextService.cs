using System.Security.Claims;
using main_menu.Database.Repositories;

namespace main_menu.Services
{
	public class HttpContextService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly HttpContextRepository _repository;

		public HttpContextService(IHttpContextAccessor httpContextAccessor, HttpContextRepository repository)
		{
			_httpContextAccessor = httpContextAccessor;
			_repository = repository;
		}

		internal Guid UserId
		{
			get
			{
				var userIdentifier = _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
				return Guid.TryParse(userIdentifier, out var userId) ? userId : Guid.Empty;
			}
		}

		internal async Task<Guid> GetCompanyId()
		{
			return await _repository.GetCompanyId(UserId);
		}
	}
}