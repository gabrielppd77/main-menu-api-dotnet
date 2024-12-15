using main_menu.Database.Repositories;
using main_menu.DTOS.ProductDTO;
using main_menu.Models;
using main_menu.Utils;

namespace main_menu.Services
{
	public class ProductService
	{
		private readonly ProductRepository _repository;
		private readonly HttpContextService _httpContextService;
		private readonly ImageManagerService _imageManagerService;

		public ProductService(ProductRepository repository, HttpContextService httpContextService, ImageManagerService imageManagerService)
		{
			_repository = repository;
			_httpContextService = httpContextService;
			_imageManagerService = imageManagerService;
		}

		internal async Task<List<ProductResponseTableDTO>> GetAll()
		{
			var companyId = await _httpContextService.GetCompanyId();
			var products = await _repository.GetAllByCompany(companyId);
			return products.Select(x => new ProductResponseTableDTO()
			{
				Id = x.Id,
				Name = x.Name,
				Description = x.Description,
				Order = x.Order,
				Price = x.Price,
				CategoryName = x.Category!.Name,
			}).ToList();
		}

		internal async Task Create(ProductRequestDTO request)
		{
			var companyId = await _httpContextService.GetCompanyId();
			var product = new Product()
			{
				Id = Guid.NewGuid(),
				// CompanyId = companyId,
				CategoryId = request.CategoryId,
				Name = request.Name,
				Description = request.Description,
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

		internal async Task UpdateImage(Guid id, IFormFile file)
		{
			var product = await _repository.GetById(id);

			if (product == null)
			{
				throw new BadHttpRequestException("Não foi possível encontrar o produto.");
			}

			if (!string.IsNullOrEmpty(product.UrlImage))
			{
				var fileName = Path.GetFileName(product.UrlImage);
				_imageManagerService.RemoveImage(fileName, Constants.ProductBucket);
			}

			var urlImage = await _imageManagerService.UploadImage(file, Constants.ProductBucket);

			product.UrlImage = urlImage;

			await _repository.SaveChanges();
		}

		internal async Task<ProductResponseFormDTO> GetById(Guid id)
		{
			var product = await _repository.GetById(id);

			if (product == null)
			{
				throw new BadHttpRequestException("Não foi possível encontrar o produto.");
			}

			return new ProductResponseFormDTO()
			{
				Id = product.Id,
				Name = product.Name,
				Description = product.Description,
				Order = product.Order,
				Price = product.Price,
				UrlImage = product.UrlImage,
				CategoryId = product.CategoryId,
			};
		}
	}
}