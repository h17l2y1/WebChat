using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebChat.BusinessLogic.Providers;
using WebChat.BusinessLogic.Providers.Interfaces;
using WebChat.BusinessLogic.Services;
using WebChat.BusinessLogic.Services.Interfaces;
using WebChat.DataAccess.Config;
using WebChat.DataAccess.Domain;
using WebChat.Entities.Entities;

namespace WebChat.BusinessLogic.Config
{
	public static class ConfigureBusinessLogic
	{
		public static void InjectBusinessLogicDependency(this IServiceCollection services, IConfiguration сonfiguration)
		{
			var config = new AutoMapper.MapperConfiguration(c =>
			{
				c.AddProfile(new MapperProfile());
			});
			var mapper = config.CreateMapper();

			services.AddSingleton(mapper);
			services.InjectDataAccessDependency(сonfiguration);
			//services.AddSignalRCore();

			services.AddIdentity<User, UserRole>().AddEntityFrameworkStores<ApplicationContext>();

			JwtSettings(services, сonfiguration);


			// Services;
			services.AddScoped<IAccountService, AccountService>();


			// Providers;
			services.AddScoped<IJwtTokenProvider, JwtTokenProvider>();

			
			// Helpers;


		}

		private static void JwtSettings(IServiceCollection services, IConfiguration сonfiguration)
		{
			var appSettingsSection = сonfiguration.GetSection("AuthOptions");
			var appSettings = appSettingsSection.Get<AuthOptions>();
			var byteKey = Encoding.ASCII.GetBytes(appSettings.Key);
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				options.RequireHttpsMetadata = false;
				options.SaveToken = true;
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidIssuer = appSettings.Issuer,
					ValidAudience = appSettings.Audience,
					ValidateLifetime = true,
					IssuerSigningKey = new SymmetricSecurityKey(byteKey),
					ValidateIssuerSigningKey = true,
				};
			});
		}

	}
}
