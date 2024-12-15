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

		internal async Task<Company?> GetByUser(Guid userId)
		{
			return await _context.Company.Where(x => x.UserId == userId).FirstOrDefaultAsync();
		}

		internal async Task SaveChanges()
		{
			await _context.SaveChangesAsync();
		}
	}
}