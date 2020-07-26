using HybridChat.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HybridChat.Controllers
{
    [Route("api/[controller]/[action]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        public MessageController(IMessageService messageService) {
            _messageService = messageService;
        }

        [HttpPut]
        public JsonResult SendMessage(Guid user, string message)
        {
            return new JsonResult(_messageService.SendMessage(user, message).Result);
        }

        [HttpGet]
        public JsonResult GetMessages()
        {
            return new JsonResult(_messageService.GetMessages());
        }
    }
}
