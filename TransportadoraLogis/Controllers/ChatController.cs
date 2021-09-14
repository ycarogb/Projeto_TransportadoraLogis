using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportadoraLogis.Data;
using TransportadoraLogis.Hubs;
using TransportadoraLogis.Models;

namespace TransportadoraLogis.Controllers
{
    public class ChatController : Controller
    {
        public readonly UserManager<AppUser> _userManager;
        public readonly ProdutoContext _context;
        public ChatController(UserManager<AppUser> userManager, ProdutoContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            ViewBag.CurrentUserName = currentUser.UserName;
            ViewBag.Messages = _context.Messages.ToList();
            return View();
        }

        public async Task<IActionResult> SendMessage(string texto,[FromServices] IHubContext<ChatHub> chat)
        {

            var sender = await _userManager.GetUserAsync(User);
            Message message = new Message
            {
                Text = texto,
                UserName = User.Identity.Name,
                UserId = sender.Id,
                Datetime = DateTime.Now
            };

            _context.Messages.Add(message);
            _context.SaveChanges();
            await chat.Clients.All.SendAsync("RecieveMessage", message);

            return Ok();
        }


    }
}
