using main_menu.Database;
using main_menu.Database.Repositories;
using main_menu.Interfaces.Repositories;
using main_menu.Interfaces.Services;
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
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<TokenService>();
			services.AddScoped<HttpContextService>();
			services.AddScoped<CompanyService>();
			services.AddScoped<CategoryService>();
			services.AddScoped<ProductService>();
			services.AddScoped<ClientService>();
			services.AddScoped<ProjectService>();
			services.AddScoped<QRCodeGeneratorService>();
			services.AddScoped<ImageManagerService>();
		}

		public static void AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<CompanyRepository>();
			services.AddScoped<CategoryRepository>();
			services.AddScoped<ProductRepository>();
			services.AddScoped<ClientRepository>();
			services.AddScoped<ProjectRepository>();
		}
	}
}