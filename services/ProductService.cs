using main_menu.database.repositories;
using main_menu.dtos;
using main_menu.models;

namespace main_menu.services
{
	public class ProductService
	{
		private readonly ProductRepository _repository;

		public ProductService(ProductRepository repository)
		{
			_repository = repository;
		}

		internal async Task Create(ProductCreate request)
		{
			var product = new Product()
			{
				Id = Guid.NewGuid(),
				Name = request.Name,
				Description = request.Description,
				ImageUrl = request.ImageUrl,
				Order = request.Order,
				Price = request.Price,
				CategoryId = request.CategoryId,
			};
			await _repository.AddProduct(product);
			await _repository.SaveChanges();
		}

		internal async Task Remove(Guid id)
		{
			var product = await _repository.GetById(id);

			if (product == null)
			{
				throw new BadHttpRequestException("Não foi possível encontrar o produto.");
			}

			_repository.RemoveProduct(product);

			await _repository.SaveChanges();
		}

		internal async Task Update(Guid id, ProductUpdate request)
		{
			var product = await _repository.GetById(id);

			if (product == null)
			{
				throw new BadHttpRequestException("Não foi possível encontrar o produto.");
			}

			product.Name = request.Name;
			product.Description = request.Description;
			product.ImageUrl = request.ImageUrl;
			product.Order = request.Order;
			product.Price = request.Price;
			product.CategoryId = request.CategoryId;

			await _repository.SaveChanges();
		}
	}
}