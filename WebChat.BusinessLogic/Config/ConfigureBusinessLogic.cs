using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebChat.DataAccess.Config;

namespace WebChat.BusinessLogic.Config
{
	public static class ConfigureBusinessLogic
	{
		public static void InjectBusinessLogicDependency(this IServiceCollection services, IConfiguration сonfiguration)
		{
			//Automapper setup
			var config = new AutoMapper.MapperConfiguration(c =>
			{
				c.AddProfile(new MapperProfile());
			});
			var mapper = config.CreateMapper();
			services.AddSingleton(mapper);

			services.InjectDataAccessDependency(сonfiguration);


			// Services;
			//services.AddScoped<Interface, Services>();




			// Providers;

			// Helpers;


		}

	}
}
