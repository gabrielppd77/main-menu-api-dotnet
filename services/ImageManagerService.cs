namespace main_menu.Services
{
	public class ImageManagerService
	{
		private readonly string _uploadPath = "/var/www/images";
		private readonly string[] allowedExtensions = { ".jpg", ".png" };

		public async Task<string> UploadImage(IFormFile file)
		{
			if (file == null || file.Length == 0)
			{
				throw new BadHttpRequestException("Não foi possível encontrar o arquivo.");
			}

			if (!allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
			{
				throw new BadHttpRequestException("A extensão do arquivo não é suportada.");
			}

			var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

			var filePath = Path.Combine(_uploadPath, fileName);

			try
			{
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}

				return fileName;
			}
			catch (Exception ex)
			{
				throw new Exception("Tentar salvar o arquivo.", ex);
			}
		}
	}
}