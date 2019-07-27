using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebChat.Entities.Entities
{
	public abstract class BaseEntity : IBaseEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		public DateTime CreationDate { get; set; }

		public BaseEntity()
		{
			CreationDate = DateTime.UtcNow;
		}
	}
}
