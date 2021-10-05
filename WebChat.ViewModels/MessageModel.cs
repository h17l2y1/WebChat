using System;
using System.ComponentModel.DataAnnotations;

namespace WebChat.ViewModels
{
    public class MessageModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public string UserId { get; set; }
        public bool IsEdited { get; set; }
    }
}