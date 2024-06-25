using System.Text;
using main_menu.settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace main_menu.configurations
{
	public static class BuilderConfig
	{
		public static void ConfigBuild(this WebApplicationBuilder builder)
		{
			builder.AddServices();
			builder.AddConfigs();
			builder.AddJWT();
		}

		public static void AddServices(this WebApplicationBuilder builder)
		{
			builder.Services.AddControllers();
			builder.Services.AddContexts();
			builder.Services.AddServices();
			builder.Services.AddRepositories();
		}

		public static void AddConfigs(this WebApplicationBuilder builder)
		{
			builder.Services.Configure<JwtSetting>(builder.Configuration.GetSection("JwtSetting"));
		}

		public static void AddJWT(this WebApplicationBuilder builder)
		{
			var secret = builder.Configuration["JwtSetting:Secret"];
			if (string.IsNullOrEmpty(secret))
			{
				throw new InvalidOperationException("Jwt Configuration, Secret Key not found.");
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
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
					ValidateIssuer = false,
					ValidateAudience = false,
					ValidateLifetime = true
				};
			});
		}
	}
}