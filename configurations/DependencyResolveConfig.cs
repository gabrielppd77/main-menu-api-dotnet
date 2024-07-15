using main_menu.database.context;
using main_menu.services;
using main_menu.database.repositories;

namespace main_menu.configurations
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
			services.AddScoped<CategoryService>();
			services.AddScoped<ProductService>();
		}

		public static void AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<UserRepository>();
			services.AddScoped<CategoryRepository>();
			services.AddScoped<ProductRepository>();
		}
	}
}