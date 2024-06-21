using Microsoft.EntityFrameworkCore;

using main_menu.configurations;
using main_menu.models;

namespace main_menu.repositories
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