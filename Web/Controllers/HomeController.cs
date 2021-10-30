using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels;
using System.Security.Cryptography;
using Core;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork<User> _userConnected;
        private readonly IUnitOfWork<Item> _item;

        public HomeController(IUnitOfWork<User> userConnected, IUnitOfWork<Item> Item)
        {
            _userConnected = userConnected;
            _item = Item;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
