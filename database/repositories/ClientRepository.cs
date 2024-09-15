using main_menu.Contexts;
using main_menu.DTOS.ClientDTOS;
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

		internal async Task<ClientResponseDTO?> GetMainData(string urlSite)
		{
			return await _context.Company
				.AsNoTracking()
				.Where(x => x.UrlSite == urlSite)
				.Select(x => new ClientResponseDTO()
				{
					CompanyName = x.Name,
					Categories = x.Categories.Select(cat => new ClientCategoryResponseDTO()
					{
						Id = cat.Id,
						Name = cat.Name,
						Order = cat.Order,
						Products = cat.Products.Select(prod => new ClientProductResponseDTO()
						{
							Id = prod.Id,
							Name = prod.Name,
							Description = prod.Description,
							UrlImage = prod.UrlImage,
							Order = prod.Order,
							Price = prod.Price,
						}).ToList(),
					}).ToList()
				})
				.FirstOrDefaultAsync();
		}
	}
}