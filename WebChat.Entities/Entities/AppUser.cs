using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WebChat.Entities.Entities
{
    public class AppUser : IdentityUser
    {
        public virtual ICollection<Message> Messages { get; set; }

        public AppUser()
        {
            Messages = new HashSet<Message>();
        }
    }
}