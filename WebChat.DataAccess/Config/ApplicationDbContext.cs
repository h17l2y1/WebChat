using Microsoft.EntityFrameworkCore;
using WebChat.Entities.Entities;

namespace WebChat.DataAccess.Config
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
        
		public DbSet<Message> Messages { get; set; }
	}
}
