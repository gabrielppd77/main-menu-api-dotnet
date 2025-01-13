using Microsoft.EntityFrameworkCore;
using main_menu.Models;
using main_menu.Interfaces.Repositories;

namespace main_menu.Database.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly PgContext _context;

		public UserRepository(PgContext context)
		{
			_context = context;
		}

		public async Task AddUser(User user)
		{
			await _context.User.AddAsync(user);
		}

		public async Task AddCompany(Company company)
		{
			await _context.Company.AddAsync(company);
		}

		public async Task<User?> FindByEmail(string email)
		{
			return await _context.User.Where(x => x.Email == email).FirstOrDefaultAsync();
		}

		public async Task SaveChanges()
		{
			await _context.SaveChangesAsync();
		}

		public async Task<User?> GetById(Guid userId)
		{
			return await _context.User.FirstOrDefaultAsync(x => x.Id == userId);
		}

		public void RemoveUser(User user)
		{
			_context.User.Remove(user);
		}
	}
}