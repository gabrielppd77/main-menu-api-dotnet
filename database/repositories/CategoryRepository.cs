using main_menu.Contexts;
using main_menu.Models;
using Microsoft.EntityFrameworkCore;

namespace main_menu.Database.Repositories
{
	public class CategoryRepository
	{
		private readonly PgContext _context;

		public CategoryRepository(PgContext context)
		{
			_context = context;
		}

		internal async Task AddCategory(Category category)
		{
			throw new Exception("");
			// await _context.Category.AddAsync(category);
		}

		internal async Task<List<Category>> GetAllByUser(Guid userId)
		{
			throw new Exception("");
			// return await _context.Category
			// 	// .Where(x => x.UserId == userId)
			// 	.OrderBy(x => x.Order)
			// 	.ToListAsync();
		}

		internal async Task<Category?> GetById(Guid id)
		{
			throw new Exception("");
			// return await _context.Category.Where(x => x.Id == id).FirstOrDefaultAsync();
		}

		internal void RemoveCategory(Category category)
		{
			throw new Exception("");
			// _context.Category.Remove(category);
		}

		internal async Task SaveChanges()
		{
			await _context.SaveChangesAsync();
		}
	}
}