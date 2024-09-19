using main_menu.Models;
using Microsoft.EntityFrameworkCore;

namespace main_menu.Database.Repositories
{
	public class CompanyRepository
	{
		private readonly PgContext _context;

		public CompanyRepository(PgContext context)
		{
			_context = context;
		}

		internal async Task<Company?> GetById(Guid id)
		{
			return await _context.Company.Where(x => x.Id == id).FirstOrDefaultAsync();
		}

		internal async Task SaveChanges()
		{
			await _context.SaveChangesAsync();
		}
	}
}