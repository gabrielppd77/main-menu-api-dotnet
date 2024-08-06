using main_menu.Contexts;
using main_menu.Services;
using main_menu.Database.repositories;

namespace main_menu.Configurations
{
	public static class DependencyResolveConfig
	{
		public static void AddContexts(this IServiceCollection services)
		{
			services.AddScoped<PgContext>();
			services.AddScoped<UserContext>();
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