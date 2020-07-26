using System;

namespace HybridChat.Entities.DTO
{
    public class MessageDto
    {
        public string Message { get; set; }
        public Guid MessageId { get; set; }
        public Guid UserId { get; set; }
    }
}
