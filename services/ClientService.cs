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

		internal async Task<List<ClientResponseDTO>> GetAll()
		{
			var categories = await _repository.GetAllCategories();
			var products = await _repository.GetAllProducts();

			var data = new List<ClientResponseDTO>();

			foreach (var category in categories)
			{
				// var productsData = products
				// 	.Where(x => x.CategoryId == category.Id)
				// 	.Select(x => new ClientProductResponseDTO(x))
				// 	.ToList();

				// data.Add(new ClientResponseDTO(category)
				// {
				// 	Products = productsData
				// });
			}

			return data;
		}
	}
}