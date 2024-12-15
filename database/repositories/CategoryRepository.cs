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
			await _context.Category.AddAsync(category);
		}

		internal async Task<List<Category>> GetAllByUser(Guid userId)
		{
			return await _context.Category
				.Where(x => x.Company!.UserId == userId)
				.OrderBy(x => x.Order)
				.ToListAsync();
		}

		internal async Task<Category?> GetById(Guid id)
		{
			return await _context.Category.Where(x => x.Id == id).FirstOrDefaultAsync();
		}

		internal async Task<Guid> GetCompanyIdByUser(Guid userId)
		{
			return await _context.Company
				.Where(x => x.UserId == userId)
				.Select(x => x.Id)
				.FirstOrDefaultAsync();
		}

		internal void RemoveCategory(Category category)
		{
			_context.Category.Remove(category);
		}

		internal async Task SaveChanges()
		{
			await _context.SaveChangesAsync();
		}
	}
}