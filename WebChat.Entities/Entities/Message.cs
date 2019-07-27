using System;
using System.ComponentModel.DataAnnotations;

namespace WebChat.Entities.Entities
{
	public class Message
	{
		public long Id { get; set; }
		public long RoomId { get; set; }
		public long UserId { get; set; }
		[Required]
		public string UserName { get; set; }
		[Required]
		public string Text { get; set; }
		public DateTime Time { get; set; }
	}
}
