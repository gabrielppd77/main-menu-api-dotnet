namespace main_menu.configurations
{
	public static class AppConfig
	{
		public static void ConfigApp(this WebApplication app)
		{
			app.UseHttpsRedirection();
			app.MapControllers();
			app.MapGet("/", () => "Server is Living!");
			app.UseAuthentication();
			app.UseAuthorization();
		}
	}
}