using System.Text;
using main_menu.Settings;
using main_menu.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace main_menu.Configurations
{
	public static class BuilderConfig
	{
		public static void ConfigBuild(this WebApplicationBuilder builder)
		{
			builder.AddConfigServices();
			builder.AddConfigs();
			builder.AddJWT();
			builder.AddCorsPolicy();
		}

		public static void AddConfigServices(this WebApplicationBuilder builder)
		{
			builder.Services.AddControllers();
			builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
			builder.Services.AddProblemDetails();
			builder.Services.AddHttpContextAccessor();
			builder.Services.AddContexts();
			builder.Services.AddServices();
			builder.Services.AddRepositories();
		}

		public static void AddConfigs(this WebApplicationBuilder builder)
		{
			builder.Services.Configure<JwtSetting>(builder.Configuration.GetSection(nameof(JwtSetting)));
			builder.Services.Configure<MigrationsSetting>(builder.Configuration.GetSection(nameof(MigrationsSetting)));
			builder.Services.Configure<ClientSetting>(builder.Configuration.GetSection(nameof(ClientSetting)));
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

		public static void AddCorsPolicy(this WebApplicationBuilder builder)
		{
			builder.Services.AddCors(options =>
			{
				options.AddPolicy(Constants.CorsPolicy,
					builder => builder
						.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader());
			});
		}
	}
}