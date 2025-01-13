using main_menu.Models;

namespace main_menu.Interfaces.Repositories
{
	public interface IUserRepository
	{
		Task AddUser(User user);
		Task AddCompany(Company company);
		Task<User?> FindByEmail(string email);
		Task SaveChanges();
		Task<User?> GetById(Guid userId);
		void RemoveUser(User user);
	}
}