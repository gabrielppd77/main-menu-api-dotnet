using main_menu.services;
using main_menu.repositories;

namespace main_menu.configurations
{
	public static class DependencyResolveConfig
	{
		public static IServiceCollection ResolveServiceDependecy(this IServiceCollection services)
		{
			services.AddScoped<UserService>();
			services.AddScoped<TokenService>();

			return services;
		}

		public static IServiceCollection ResolveRepositoryDependecy(this IServiceCollection services)
		{
			services.AddScoped<UserRepository>();

			return services;
		}
	}
}