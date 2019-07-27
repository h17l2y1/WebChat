using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebChat.Entities.Entities
{
	[Table("AspNetUsers")]
	public class User : IdentityUser<long>, IBaseEntity
	{
		public DateTime CreationDate { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }

		public User()
		{
			CreationDate = DateTime.UtcNow;
		}
	}
}
