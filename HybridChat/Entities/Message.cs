using System;

namespace HybridChat.Entities
{
    public class Message
    {
        public Guid MessageId { get; set; }
        public string MessageContent { get; set; }
        public User UserId { get; set; }
        public virtual User User { get; set; }
    }
}
