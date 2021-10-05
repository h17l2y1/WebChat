namespace WebChat.Entities.Entities
{
    public class Message : BaseEntity
    {
        public string UserName { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public bool IsEdited { get; set; }
    }
}