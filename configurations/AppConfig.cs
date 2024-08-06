using main_menu.Utils;

namespace main_menu.Configurations
{
	public static class AppConfig
	{
		public static void ConfigApp(this WebApplication app)
		{
			app.UseCors(Constants.CorsPolicy);
			app.UseHttpsRedirection();
			app.MapControllers().RequireAuthorization();
			app.MapGet("/", () => "Server is Living!");
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseExceptionHandler();
		}
	}
}