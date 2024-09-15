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

		internal async Task<ClientResponseDTO> GetMainData(string urlSite)
		{
			var company = await _repository.GetMainData(urlSite);

			if (company == null)
			{
				throw new BadHttpRequestException("Não foi possível encontrar a empresa.");
			}

			return company;
		}
	}
}