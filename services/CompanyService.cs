using main_menu.Database.Repositories;
using main_menu.DTOS.CompanyDTOS;

namespace main_menu.Services
{
	public class CompanyService
	{
		private readonly CompanyRepository _repository;
		private readonly HttpContextService _httpContextService;

		public CompanyService(CompanyRepository repository, HttpContextService httpContextService)
		{
			_repository = repository;
			_httpContextService = httpContextService;
		}

		internal async Task<CompanyResponseDTO> GetCompany()
		{
			var companyId = await _httpContextService.GetCompanyId();

			var company = await _repository.GetById(companyId);

			if (company == null)
			{
				throw new BadHttpRequestException("Não foi possível encontrar a Empresa.");
			}

			return new CompanyResponseDTO()
			{
				Id = company.Id,
				Name = company.Name,
				Description = company.Description,
				UrlImage = company.UrlImage
			};
		}

		internal async Task Update(Guid id, CompanyUpdateDTO request)
		{
			var company = await _repository.GetById(id);

			if (company == null)
			{
				throw new BadHttpRequestException("Não foi possível encontrar a Empresa.");
			}

			company.Name = request.Name;
			company.Description = request.Description;
			company.UrlImage = request.UrlImage;

			await _repository.SaveChanges();
		}
	}
}