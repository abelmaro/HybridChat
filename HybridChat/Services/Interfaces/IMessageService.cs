using HybridChat.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HybridChat.Services.Interfaces
{
    public interface IMessageService
    {
        Task<Guid> SendMessage(Guid user, string message);
        List<MessageDto> GetMessages();

    }
}
