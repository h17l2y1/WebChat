using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebChat.DataAccess.Domain;
using WebChat.Entities.Enums;

namespace WebChat.DataAccess.Config
{
	public static class ConfigureDataAccess
	{
		public static void InjectDataAccessDependency(this IServiceCollection services, IConfiguration сonfiguration)
		{
			//	Setup ORM
			//	ORM:Entity or "ORM:Dapper";


			string ORM = сonfiguration.GetSection("ORM:Entity").Value;

			if (ORM == ORMType.EntityFramework.ToString())
			{
				services.AddDbContext<ApplicationContext>(options => options
					.UseSqlServer(сonfiguration.GetSection("ConnectionStrings:DefaultConnection").Value));

				//services.AddScoped<Interface, Repository>();
			}

			if (ORM == ORMType.Dapper.ToString())
			{
				services.Configure<ConnectionStrings>(x => сonfiguration.GetSection("ConnectionStrings").Bind(x));

				//services.AddTransient<Interface, Repository>();
			}

		}
	}
}
