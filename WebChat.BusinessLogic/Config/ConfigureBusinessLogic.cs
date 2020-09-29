using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebChat.BusinessLogic.Services;
using WebChat.BusinessLogic.Services.Interfaces;
using WebChat.DataAccess.Config;

namespace WebChat.BusinessLogic.Config
{
	public static class ConfigureBusinessLogic
	{
        public static void InjectBusinessLogicDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.InjectDataAccessDependency(configuration);
            ImplementServices(services);
        }
        
        private static void ImplementServices(IServiceCollection services)
        {
            services.AddScoped<ICardService, CardService>();
        }
	}
}
