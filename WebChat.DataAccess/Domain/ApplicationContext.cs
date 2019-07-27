using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebChat.Entities.Entities;

namespace WebChat.DataAccess.Domain
{
	public class ApplicationContext : IdentityDbContext<User, UserRole, long>
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
		}

		public string DefaultConnection { get; set; }

		//public DbSet<User> User { get; set; }


	}
}
