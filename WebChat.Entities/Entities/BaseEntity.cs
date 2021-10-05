using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebChat.Entities.Interfaces;

namespace WebChat.Entities.Entities
{
	public class BaseEntity : IBaseEntity
	{
		public BaseEntity()
		{
			Id = Guid.NewGuid().ToString();
			CreationDate = DateTime.UtcNow;
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }
		public DateTime CreationDate { get; set; }
	}
}
