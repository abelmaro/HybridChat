using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace HybridChat.Hubs
{
    public class HybridChatHub : Hub, IHybridChatHub
    {
        protected IHubContext<HybridChatHub> _hubService;

        public HybridChatHub(IHubContext<HybridChatHub> hubService)
        {
            _hubService = hubService;
        }
        public async Task SendMessageEvent(string user, string message)
        {
            await _hubService.Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }

    public interface IHybridChatHub  {
        Task SendMessageEvent(string user, string message);
    }
}
