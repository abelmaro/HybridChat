using System;
using System.Collections.Generic;

namespace HybridChat.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }

        public virtual List<Message> Messages { get; set; }
    }
}
