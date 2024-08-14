using Microsoft.AspNetCore.SignalR;

namespace BusTracking.API.signalr
{
    public class NotificationHub : Hub
    {

   
        public async Task sendNotification(string message)
        {
            await Clients.All.SendAsync("ReceiveNotification", message);
            //await Clients.Client(connectionId: Context.ConnectionId).SendAsync("ReceiveNotification",message);
        }
    }
}
