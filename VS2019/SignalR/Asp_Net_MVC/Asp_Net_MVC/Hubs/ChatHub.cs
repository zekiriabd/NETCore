using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Asp_Net_MVC.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SandMessage(string fromUser, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", fromUser, message);
        }
    }
}
