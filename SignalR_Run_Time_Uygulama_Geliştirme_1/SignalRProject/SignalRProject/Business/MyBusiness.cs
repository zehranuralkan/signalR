﻿using Microsoft.AspNetCore.SignalR;
using SignalRProject.Hubs;
using System.Threading.Tasks;

namespace SignalRProject.Business
{
    public class MyBusiness
    {
        IHubContext<MyHub> _hubContext;

        public MyBusiness(IHubContext<MyHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async Task SendMessageAsync(string message)
        {
            await _hubContext.Clients.All.SendAsync("receiveMessage", message);
        }
    }
}
