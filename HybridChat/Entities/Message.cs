using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HybridChat.Entities
{
    public class Message
    {
        public Guid MessageId { get; set; }
        public string MessageContent { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
