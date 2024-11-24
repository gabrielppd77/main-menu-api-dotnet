using main_menu.Database.Repositories;
using main_menu.DTOS.CompanyDTOS;
using main_menu.Settings;
using Microsoft.Extensions.Options;

namespace main_menu.Services
{
	public class CompanyService
	{
		private readonly CompanyRepository _repository;
		private readonly HttpContextService _httpContextService;
		private readonly QRCodeGeneratorService _qrCodeGeneratorService;
		private readonly IOptions<DomainSetting> _domainSetting;

		public CompanyService(CompanyRepository repository, HttpContextService httpContextService, QRCodeGeneratorService qrCodeGeneratorService, IOptions<DomainSetting> domainSetting)
		{
			_repository = repository;
			_httpContextService = httpContextService;
			_qrCodeGeneratorService = qrCodeGeneratorService;
			_domainSetting = domainSetting;
		}

		internal async Task<CompanyResponseDTO> GetCompany()
		{
			var companyId = await _httpContextService.GetCompanyId();

			var company = await _repository.GetById(companyId);

			if (company == null)
			{
				throw new BadHttpRequestException("Não foi possível encontrar a loja.");
			}

			return new CompanyResponseDTO()
			{
				Id = company.Id,
				Name = company.Name,
				Path = company.Path,
				Description = company.Description,
				UrlImage = company.UrlImage
			};
		}

		internal async Task Update(Guid id, CompanyUpdateDTO request)
		{
			var company = await _repository.GetById(id);

			if (company == null)
			{
				throw new BadHttpRequestException("Não foi possível encontrar a loja.");
			}

			company.Name = request.Name;
			company.Path = request.Path;
			company.Description = request.Description;

			await _repository.SaveChanges();
		}

		internal async Task<byte[]> GetQRCode()
		{
			var companyId = await _httpContextService.GetCompanyId();

			var company = await _repository.GetById(companyId);

			if (company == null)
			{
				throw new BadHttpRequestException("Não foi possível encontrar a loja.");
			}

			var urlQrCode = _domainSetting.Value.ClientDomain + "/" + company.Path;
			var qrCode = _qrCodeGeneratorService.GenerateQRCode(urlQrCode);

			return qrCode;
		}

		internal async Task UpdateImage(Guid id, string urlImage)
		{
			var company = await _repository.GetById(id);

			if (company == null)
			{
				throw new BadHttpRequestException("Não foi possível encontrar a loja.");
			}

			company.UrlImage = urlImage;

			await _repository.SaveChanges();
		}
	}
}