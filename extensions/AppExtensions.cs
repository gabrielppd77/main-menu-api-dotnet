namespace main_menu.extensions
{
	public static class AppExtensions
	{
		public static void Config(this WebApplication app)
		{
			app.UseHttpsRedirection();
			app.MapControllers();
			app.MapGet("/", () => "Server is Living!");
			app.UseAuthentication();
			app.UseAuthorization();
		}
	}
}