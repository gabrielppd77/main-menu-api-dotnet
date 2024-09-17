using Microsoft.EntityFrameworkCore;

namespace main_menu.Database.Repositories
{
	public class HttpContextRepository
	{
		private readonly PgContext _context;

		public HttpContextRepository(PgContext context)
		{
			_context = context;
		}

		internal async Task<Guid> GetCompanyId(Guid userId)
		{
			return await _context.Company
				.AsNoTracking()
				.Where(x => x.UserId == userId)
				.Select(x => x.Id)
				.FirstOrDefaultAsync();
		}
	}
}