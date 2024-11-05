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

		internal async Task<List<Company>> GetAllCompanies()
		{
			return await _context.Company.ToListAsync();
		}

		internal async Task<Company?> GetCompanyData(string companyPath)
		{
			return await _context.Company
				.AsNoTracking()
				.Include(x => x.Categories!.OrderBy(d => d.Order)).ThenInclude(x => x.Products!.OrderBy(d => d.Order))
				.Where(x => x.Path == companyPath)
				.FirstOrDefaultAsync();
		}
	}
}