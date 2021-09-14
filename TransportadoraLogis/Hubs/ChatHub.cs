using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportadoraLogis.Data;
using TransportadoraLogis.Models;

namespace TransportadoraLogis.Hubs
{
    public class ChatHub : Hub
    {
        ProdutoContext _context;
        IHttpContextAccessor _httpContextAccessor;
        public ChatHub(ProdutoContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task SendMessage(Message m)
        {
            m.Datetime = DateTime.Now;
            _context.Messages.Add(m);
            _context.SaveChanges();
            await Clients.All.SendAsync("ReceiveMessage", m);
        }

        public string GetConnectionId() => Context.ConnectionId;

    }
}
