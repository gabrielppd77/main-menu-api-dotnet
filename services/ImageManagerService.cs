using main_menu.Settings;
using Microsoft.Extensions.Options;

namespace main_menu.Services
{
	public class ImageManagerService
	{
		private readonly IOptions<DomainSetting> _domainSetting;

		private readonly string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };

		public ImageManagerService(IOptions<DomainSetting> domainSetting)
		{
			_domainSetting = domainSetting;
		}

		public async Task<string> UploadImage(IFormFile file, string bucket)
		{
			if (file == null || file.Length == 0)
			{
				throw new BadHttpRequestException("Não foi possível encontrar o arquivo.");
			}

			if (!allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
			{
				throw new BadHttpRequestException("A extensão do arquivo não é suportada.");
			}

			if (file.Length > 5 * 1024 * 1024)
			{
				throw new BadHttpRequestException("O arquivo informado é muito grande (Limite 5 MB).");
			}

			var uploadDirectory = Path.Combine("/app/images", bucket);

			if (!Directory.Exists(uploadDirectory))
			{
				Directory.CreateDirectory(uploadDirectory);
			}

			var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

			var filePath = Path.Combine(uploadDirectory, fileName);

			try
			{
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}

				return $"{_domainSetting.Value.ImageDomain}/{bucket}/{fileName}";
			}
			catch (Exception ex)
			{
				throw new Exception("Tentar salvar o arquivo.", ex);
			}
		}
	}
}