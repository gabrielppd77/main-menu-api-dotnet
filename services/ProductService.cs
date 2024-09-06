using main_menu.Contexts;
using main_menu.Database.Repositories;
using main_menu.DTOS.ProductDTO;
using main_menu.Models;

namespace main_menu.Services
{
	public class ProductService
	{
		private readonly ProductRepository _repository;
		private readonly UserContext _userContext;

		public ProductService(ProductRepository repository, UserContext userContext)
		{
			_repository = repository;
			_userContext = userContext;
		}

		internal async Task<List<ProductResponseDTO>> GetAll()
		{
			var products = await _repository.GetAllByUser(_userContext.UserId);
			return products.Select(x => new ProductResponseDTO(x)).ToList();
		}

		internal async Task Create(ProductRequestDTO request)
		{
			var product = new Product()
			{
				Id = Guid.NewGuid(),
				// UserId = _userContext.UserId,
				CategoryId = request.CategoryId,
				Name = request.Name,
				Description = request.Description,
				UrlImage = request.UrlImage,
				Order = request.Order,
				Price = request.Price,
			};
			await _repository.AddProduct(product);
			await _repository.SaveChanges();
		}

		internal async Task Update(Guid id, ProductRequestDTO request)
		{
			var product = await _repository.GetById(id);

			if (product == null)
			{
				throw new BadHttpRequestException("Não foi possível encontrar o produto.");
			}

			product.CategoryId = request.CategoryId;
			product.Name = request.Name;
			product.Description = request.Description;
			product.UrlImage = request.UrlImage;
			product.Order = request.Order;
			product.Price = request.Price;

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
	}
}