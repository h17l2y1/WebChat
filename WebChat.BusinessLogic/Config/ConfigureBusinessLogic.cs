using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebChat.BusinessLogic.MapperProfiles;
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
            InjectServices(services);
            AddAutoMapper(services);
        }
        
        private static void AddAutoMapper(IServiceCollection services)
        {
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new MessageProfile());
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }
        
        private static void InjectServices(IServiceCollection services)
        {
            services.AddScoped<IChatService, ChatService>();
        }
	}
}
