using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebChat.BusinessLogic.Helpres;
using WebChat.BusinessLogic.Helpres.Interfaces;
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
			services.JwtSetup(сonfiguration);

			services.AddIdentity<User, UserRole>().AddEntityFrameworkStores<ApplicationContext>();


			// Services;
			services.AddScoped<IAccountService, AccountService>();


			// Providers;


			// Helpers;
			services.AddScoped<IJwtHelper, JwtHelper>();


		}
	}
}
