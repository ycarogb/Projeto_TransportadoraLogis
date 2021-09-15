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
            ViewBag.Messages = _context.Messages.Where(m => m.TargetName == null).ToList();
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

        public async Task<IActionResult> Private()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            List<IdentityUser> allUsers = _context.Users.Where(u => u.UserName != currentUser.UserName).ToList();
            return View(allUsers);
        }

        public async Task<IActionResult> PrivateMessage(string id)
        {
            var current = await _userManager.GetUserAsync(User);
            var target = await _userManager.FindByNameAsync(id);

            var sentMessages = _context.Messages.Where(m => m.UserName == current.UserName && m.TargetName == target.UserName).ToList();
            var receivedMessages = _context.Messages.Where(m => m.UserName == target.UserName && m.TargetName == current.UserName).ToList();
            var messages = sentMessages.Concat(receivedMessages).ToList();

            ViewBag.Messages = messages;
            ViewBag.CurrentUser = current;
            ViewBag.TargetUser = target;

            return View();
        }


    }
}
