using main_menu.Models;
using Microsoft.EntityFrameworkCore;

namespace main_menu.Contexts
{
	public class PgContext : DbContext
	{
		private readonly IConfiguration _configuration;

		public PgContext(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public DbSet<User> User { get; set; }
		public DbSet<Category> Category { get; set; }
		public DbSet<Product> Product { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var connectionString = _configuration.GetConnectionString("DefaultConnection");
			if (string.IsNullOrEmpty(connectionString))
			{
				throw new InvalidOperationException("Connection string not found.");
			}
			optionsBuilder.UseNpgsql(connectionString);
			base.OnConfiguring(optionsBuilder);
		}
	}
};