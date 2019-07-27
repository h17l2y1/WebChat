using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebChat.Entities.Entities
{
	[Table("AspNetUsers")]
	public class User : IdentityUser<long>
	{
		public DateTime CreationDate { get; set; }

		public User()
		{
			CreationDate = DateTime.UtcNow;
		}
	}
}
