using System.Text;
using main_menu.settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace main_menu.extensions
{
	public static class BuilderExtensions
	{
		public static void Config(this WebApplicationBuilder builder)
		{
			builder.Services.AddControllers();

			builder.Services.Configure<JwtSetting>(builder.Configuration.GetSection("JwtSetting"));

			var key = builder.Configuration["Jwt:Key"];
			if (string.IsNullOrEmpty(key))
			{
				throw new InvalidOperationException("Jwt Key not found.");
			}
			builder.Services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(x =>
			{
				x.RequireHttpsMetadata = false;
				x.SaveToken = true;
				x.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
					ValidateIssuer = false,
					ValidateAudience = false,
					ValidateLifetime = true
				};
			});
		}
	}
}