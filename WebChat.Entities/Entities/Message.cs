using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebChat.Entities.Entities
{
    [Table("Messages")]
	public class Message : BaseEntity
    {
        [Required]
        public long RoomId { get; set; }
        [Required]
        public long UserId { get; set; }
		[Required]
		public string UserName { get; set; }
		[Required]
		public string Text { get; set; }
        [Required]
        public DateTime Time { get; set; }
	}
}
