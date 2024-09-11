using main_menu.Contexts;
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

		internal async Task<List<Category>> GetAllCategories()
		{
			return await _context.Category.ToListAsync();
		}

		internal async Task<List<Product>> GetAllProducts()
		{
			return await _context.Product.ToListAsync();
		}
	}
}