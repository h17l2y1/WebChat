using System;

namespace WebChat.Entities.Entities
{
	public interface IBaseEntity
	{
		long Id { get; set; }
		DateTime CreationDate { get; set; }
	}
}
