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

		internal async Task<Company?> GetCompanyData(string companyPath, string? _query)
		{
			var query = _context.Company
				.AsNoTracking()
				.Where(x => x.Path == companyPath)
				.AsQueryable();

			if (_query != null)
			{
				query = query
					.Include(x => x.Categories!
						.OrderBy(d => d.Order)
						.Where(d => d.Products!.Where(c => c.Name.ToLower().Contains(_query.ToLower())).Any())
					)
					.ThenInclude(x => x.Products!
						.OrderBy(d => d.Order)
						.Where(d => d.Name.ToLower().Contains(_query.ToLower()))
					);
			}
			else
			{
				query = query
					.Include(x => x.Categories!.OrderBy(d => d.Order))
					.ThenInclude(x => x.Products!.OrderBy(d => d.Order));
			}

			return await query.FirstOrDefaultAsync();
		}
	}
}