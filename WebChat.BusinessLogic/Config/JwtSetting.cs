using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebChat.BusinessLogic.Config
{
	public static class JwtSetting
	{
		public static void JwtSetup(this IServiceCollection services, IConfiguration сonfiguration)
		{
			var appSettingsSection = сonfiguration.GetSection("AuthOptions");
			var appSettings = appSettingsSection.Get<AuthOptions>();
			var byteKey = Encoding.ASCII.GetBytes(appSettings.Key);

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				options.RequireHttpsMetadata = false;
				options.SaveToken = true;
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(byteKey),

					ValidateIssuer = true,
					ValidateAudience = true,
					ValidIssuer = appSettings.Issuer,
					ValidAudience = appSettings.Audience,
					ValidateLifetime = true,
				};
			});
		}
	}
}
