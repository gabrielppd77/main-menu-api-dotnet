using main_menu.Database.Repositories;
using main_menu.DTOS.ClientDTOS;

namespace main_menu.Services
{
	public class ClientService
	{
		private readonly ClientRepository _repository;

		public ClientService(ClientRepository repository)
		{
			_repository = repository;
		}

		internal async Task<ClientResponseDTO> GetMainData()
		{
			var company = await _repository.GetMainData();

			if (company == null)
			{
				throw new BadHttpRequestException("Não foi possível encontrar a empresa.");
			}

			return new ClientResponseDTO()
			{
				CompanyName = company.Name,
				CompanyDescription = company.Description,
				CompanyUrlImage = company.UrlImage,
				Categories = company.Categories!.Select(cat => new ClientCategoryResponseDTO()
				{
					Id = cat.Id,
					Name = cat.Name,
					Order = cat.Order,
					Products = cat.Products!.Select(prod => new ClientProductResponseDTO()
					{
						Id = prod.Id,
						Name = prod.Name,
						Description = prod.Description,
						UrlImage = prod.UrlImage,
						Order = prod.Order,
						Price = prod.Price,
					}).ToList()
				}).ToList()
			};
		}
	}
}