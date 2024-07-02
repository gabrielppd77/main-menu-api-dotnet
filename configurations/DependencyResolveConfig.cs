using main_menu.database.context;
using main_menu.services;
using main_menu.database.repositories;

namespace main_menu.configurations
{
	public static class DependencyResolveConfig
	{
		public static IServiceCollection AddContexts(this IServiceCollection services)
		{
			services.AddScoped<PgContext>();
			return services;
		}

		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped<UserService>();
			services.AddScoped<TokenService>();
			services.AddScoped<CategoryService>();
			services.AddScoped<ProductService>();
			return services;
		}

		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<UserRepository>();
			services.AddScoped<CategoryRepository>();
			services.AddScoped<ProductRepository>();
			return services;
		}
	}
}