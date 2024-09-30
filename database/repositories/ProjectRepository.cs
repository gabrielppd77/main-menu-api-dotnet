using Microsoft.EntityFrameworkCore;

namespace main_menu.Database.Repositories
{
	public class ProjectRepository
	{
		private readonly PgContext _context;

		public ProjectRepository(PgContext context)
		{
			_context = context;
		}

		internal async Task RunMigrations()
		{
			await _context.Database.MigrateAsync();
		}
	}
}