using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace RazApp.Core.Notification
{
    public class NotificationHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        public void SendNotifications(string message)
        {
            var signalrContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            signalrContext.Clients.All.receiveNotification(message);
           // Clients.All.receiveNotification(message);
            
        }
    }
}