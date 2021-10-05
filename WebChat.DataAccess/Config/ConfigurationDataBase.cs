using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebChat.DataAccess.Repository;
using WebChat.DataAccess.Repository.Interfaces;

namespace WebChat.DataAccess.Config
{
	public static class ConfigurationDataBase
	{
		public static void InjectDataAccessDependency(this IServiceCollection services, IConfiguration configuration)
		{
			InjectRepositories(services);
			AddDbContext(services, configuration);
		} 
		
		private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
		{
			string connectionString = configuration.GetConnectionString("DefaultConnection");
			// services.AddDbContext<ApplicationDbContext>(options =>
			// {
			// 	options.UseSqlServer(connectionString);
			// });
		}
		
		private static void InjectRepositories(IServiceCollection services)
		{
			services.AddTransient<IMessageRepository, MessageRepository>();
		}
	}
}
