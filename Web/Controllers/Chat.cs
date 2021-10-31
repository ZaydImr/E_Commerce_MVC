using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Authorize]
    public class Chat : Controller
    {
        private readonly IUnitOfWork<Message> chat;

        public Chat(IUnitOfWork<Message> chat)
        {
            this.chat = chat;
        }

        public IActionResult Index()
        {
            IEnumerable<Message> chats = chat.Entity.GetAll().ToList().Where(c=> c.usernameReceiver == User.Claims.ToList().Where(c => c.Type == "username").FirstOrDefault().Value || c.usernameProvider == User.Claims.ToList().Where(c => c.Type == "username").FirstOrDefault().Value);
            return View(chats);
        }
    }
}
