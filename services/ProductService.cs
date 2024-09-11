using main_menu.Database.Repositories;
using main_menu.DTOS.ProductDTO;
using main_menu.Models;

namespace main_menu.Services
{
	public class ProductService
	{
		private readonly ProductRepository _repository;
		private readonly HttpContextService _httpContextService;

		public ProductService(ProductRepository repository, HttpContextService httpContextService)
		{
			_repository = repository;
			_httpContextService = httpContextService;
		}

		internal async Task<List<ProductResponseDTO>> GetAll()
		{
			var companyId = await _httpContextService.GetCompanyId();
			var products = await _repository.GetAllByCompany(companyId);
			return products.Select(x => new ProductResponseDTO(x)).ToList();
		}

		internal async Task Create(ProductRequestDTO request)
		{
			var companyId = await _httpContextService.GetCompanyId();
			var product = new Product()
			{
				Id = Guid.NewGuid(),
				CompanyId = companyId,
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