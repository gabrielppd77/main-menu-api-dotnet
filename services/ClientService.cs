using main_menu.Database.Repositories;
using main_menu.DTOS.ClientDTOS;
using main_menu.Models;

namespace main_menu.Services
{
	public class ClientService
	{
		private readonly ClientRepository _repository;

		public ClientService(ClientRepository repository)
		{
			_repository = repository;
		}

		internal async Task<ClientResponseDTO> GetMainData(string urlSite)
		{
			var company = await _repository.GetMainData(urlSite);

			if (company == null)
			{
				throw new BadHttpRequestException("Não foi possível encontrar a empresa.");
			}

			var categories = new List<ClientCategoryResponseDTO>();

			foreach (var category in company.Categories)
			{
				var products = category.Products.Select(x => new ClientProductResponseDTO()
				{
					Id = x.Id,
					Name = x.Name,
					Description = x.Description,
					UrlImage = x.UrlImage,
					Order = x.Order,
					Price = x.Price,
				}).ToList();

				categories.Add(new ClientCategoryResponseDTO()
				{
					Id = category.Id,
					Name = category.Name,
					Order = category.Order,
					Products = products,
				});
			}

			return new ClientResponseDTO()
			{
				CompanyName = company.Name,
				Categories = categories,
			};
		}
	}
}