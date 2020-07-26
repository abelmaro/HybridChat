using HybridChat.Data;
using HybridChat.Entities;
using HybridChat.Entities.DTO;
using HybridChat.Hubs;
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
        private readonly IHybridChatHub _hub;
        private readonly IUserService _userService;

        public MessageService(ChatContext chatContext,
            IHybridChatHub hybridChatHub,
            IUserService userService)
        {
            _context = chatContext;
            _userService = userService;
            _hub = hybridChatHub;
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
            UserDto username = new UserDto() {
                Username = _userService.GetUserById(user).ToString()
            };

             await _context.AddAsync(messageToAdd);
            _context.SaveChanges();
            await _hub.SendMessageEvent(username.Username, message);
            return messageToAdd.MessageId;
        }
    }
}
