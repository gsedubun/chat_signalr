using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace chat_signalr.hubs
{
    public class ChatHub : Hub
    {

        public void Send(string message)
        {
            Clients.All.SendAsync("SendMessage", Context.User.Identity.Name, message);
            Groups.AddToGroupAsync("", "");

        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("SendAction", Context.User.Identity.Name, "joined");

        }



        public override async Task OnDisconnectedAsync(System.Exception exception)
        {
            await Clients.All.SendAsync("SendAction", Context.User.Identity.Name, "left");
        }

    }
}
