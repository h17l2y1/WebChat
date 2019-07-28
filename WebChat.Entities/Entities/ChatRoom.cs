using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebChat.Entities.Entities
{
    [Table("ChatRooms")]
    public class ChatRoom : BaseEntity
    {
		[Required]
		public string Name { get; set; }
        [Required]
        public long CreatorId { get; set; }
    }
}
