using main_menu.database.context;
using main_menu.models;
using Microsoft.EntityFrameworkCore;

namespace main_menu.database.repositories
{
	public class ProductRepository
	{
		private readonly PgContext _context;

		public ProductRepository(PgContext context)
		{
			_context = context;
		}

		internal async Task AddProduct(Product product)
		{
			await _context.Product.AddAsync(product);
		}

		internal async Task<Product?> GetById(Guid id)
		{
			return await _context.Product.Where(x => x.Id == id).FirstOrDefaultAsync();
		}

		internal void RemoveProduct(Product product)
		{
			_context.Product.Remove(product);
		}

		internal async Task SaveChanges()
		{
			await _context.SaveChangesAsync();
		}
	}
}