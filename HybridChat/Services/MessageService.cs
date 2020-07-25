using HybridChat.Entities;
using HybridChat.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace HybridChat.Services
{
    public class MessageService : IMessageService
    {
        public List<Message> GetMessages() {
            return new List<Message>();
        }

        public Message SendMessage(Guid user, string message) {
            return new Message();
        }
    }
}
