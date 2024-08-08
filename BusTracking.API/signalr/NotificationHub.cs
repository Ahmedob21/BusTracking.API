using Microsoft.AspNetCore.SignalR;

namespace BusTracking.API.signalr
{
    public class NotificationHub : Hub
    {
        public async Task NotifyParent(string message)
        {
            await Clients.All.SendAsync("ReceiveNotification", message);
        }
    }
}
