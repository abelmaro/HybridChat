using HybridChat.Entities;
using System;
using System.Collections.Generic;

namespace HybridChat.Services.Interfaces
{
    public interface IMessageService
    {
        Message SendMessage(Guid user, string message);
        List<Message> GetMessages();

    }
}
