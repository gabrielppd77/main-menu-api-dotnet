using main_menu.Models;
using Microsoft.EntityFrameworkCore;

namespace main_menu.Database.Repositories
{
	public class ClientRepository
	{
		private readonly PgContext _context;

		public ClientRepository(PgContext context)
		{
			_context = context;
		}

		internal async Task<Company?> GetMainData()
		{
			return await _context.Company
				.AsNoTracking()
				.Include(x => x.Categories!)
				.ThenInclude(x => x.Products)
				.FirstOrDefaultAsync();
		}
	}
}