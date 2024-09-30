using main_menu.Database.Repositories;
using main_menu.Settings;
using Microsoft.Extensions.Options;

namespace main_menu.Services
{
	public class ProjectService
	{
		private readonly IOptions<MigrationsSetting> _migrationsSetting;
		private readonly ProjectRepository _repository;

		public ProjectService(IOptions<MigrationsSetting> migrationsSetting, ProjectRepository repository)
		{
			_migrationsSetting = migrationsSetting;
			_repository = repository;
		}

		internal async Task RunMigrations(string password)
		{
			if (_migrationsSetting.Value.PasswordRunMigration != password)
			{
				throw new BadHttpRequestException("Não foi possível prosseguir, senha incorreta.");
			}
			await _repository.RunMigrations();
		}
	}
}