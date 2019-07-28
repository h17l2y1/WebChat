using System.ComponentModel.DataAnnotations;

namespace WebChat.Entities.Entities
{
    public class UserInChat : BaseEntity
    {
        [Required]
        public long UserId { get; set; }

        [Required]
        public string ChatId { get; set; }
    }
}
