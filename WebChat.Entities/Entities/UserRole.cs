using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebChat.Entities.Entities
{
	[Table("AspNetRoles")]
	public class UserRole : IdentityRole<long>
	{
		public UserRole()
		{
		}

		public UserRole(string name) : base(name)
		{
		}
	}
}
