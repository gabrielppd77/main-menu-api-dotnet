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

		internal async Task<List<ClientResponseDTO>> GetAllCompanies()
		{
			var companies = await _repository.GetAllCompanies();
			return companies
				.Select(x => new ClientResponseDTO()
				{
					CompanyId = x.Id,
					CompanyName = x.Name,
					CompanyPath = x.Path,
					CompanyDescription = x.Description,
					CompanyUrlImage = x.UrlImage,
					Categories = new List<ClientCategoryResponseDTO>()
				})
				.ToList();
		}

		internal async Task<ClientResponseDTO> GetCompanyData(string companyPath, string? query)
		{
			var company = await _repository.GetCompanyData(companyPath, query);

			if (company == null)
			{
				throw new BadHttpRequestException("Não foi possível encontrar a empresa.");
			}

			return new ClientResponseDTO()
			{
				CompanyId = company.Id,
				CompanyName = company.Name,
				CompanyPath = company.Path,
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