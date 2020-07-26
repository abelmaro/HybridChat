using HybridChat.Data;
using HybridChat.Entities;
using HybridChat.Entities.DTO;
using HybridChat.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HybridChat.Services
{
    public class MessageService : IMessageService
    {
        private readonly ChatContext _context;

        public MessageService(ChatContext chatContext)
        {
            _context = chatContext;
        }

        public List<MessageDto> GetMessages() {

            List<MessageDto> messages = new List<MessageDto>();
            List<Message> messagesDb = _context.Messages.ToList();

            foreach (var message in messagesDb)
            {
                messages.Add(
                    new MessageDto()
                    {
                        Message = message.MessageContent,
                        MessageId = message.MessageId,
                        UserId = message.UserId
                    }
                    );
            }
            return messages;
        }

        public async Task<Guid> SendMessage(Guid user, string message) {

            var messageToAdd = new Message
            {
                UserId = user,
                MessageContent = message,
                MessageId = Guid.NewGuid()
            };

             await _context.AddAsync(messageToAdd);
            _context.SaveChanges();

            return messageToAdd.MessageId;
        }
    }
}
