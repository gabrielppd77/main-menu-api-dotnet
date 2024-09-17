using main_menu.Database;
using main_menu.Database.Repositories;
using main_menu.Services;

namespace main_menu.Configurations
{
	public static class DependencyResolveConfig
	{
		public static void AddContexts(this IServiceCollection services)
		{
			services.AddScoped<PgContext>();
		}

		public static void AddServices(this IServiceCollection services)
		{
			services.AddScoped<UserService>();
			services.AddScoped<TokenService>();
			services.AddScoped<HttpContextService>();
			services.AddScoped<CategoryService>();
			services.AddScoped<ProductService>();
			services.AddScoped<ClientService>();
		}

		public static void AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<UserRepository>();
			services.AddScoped<HttpContextRepository>();
			services.AddScoped<CategoryRepository>();
			services.AddScoped<ProductRepository>();
			services.AddScoped<ClientRepository>();
		}
	}
}