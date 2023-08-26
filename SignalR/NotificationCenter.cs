using Azure.Core;
using Microsoft.AspNetCore.SignalR;
using RealTimeUber.Models;

namespace RealTimeUber.SignalR
{
    public class NotificationCenterHub : Hub
{
        public async Task SendTripRequest(Request request, string[] driverIds)
        {
            await Clients.Clients(driverIds).SendAsync("ReceiveRequest", request);
        }
    }
}

