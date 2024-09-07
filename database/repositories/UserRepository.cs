using Microsoft.EntityFrameworkCore;
using main_menu.Models;
using main_menu.Contexts;

namespace main_menu.Database.Repositories
{
	public class UserRepository
	{
		private readonly PgContext _context;

		public UserRepository(PgContext context)
		{
			_context = context;
		}

		internal async Task AddUser(User user)
		{
			await _context.User.AddAsync(user);
		}

		internal async Task AddCompany(Company company)
		{
			await _context.Company.AddAsync(company);
		}

		internal async Task<User?> FindByEmail(string email)
		{
			return await _context.User.Where(x => x.Email == email).FirstOrDefaultAsync();
		}

		internal async Task SaveChanges()
		{
			await _context.SaveChangesAsync();
		}
	}
}