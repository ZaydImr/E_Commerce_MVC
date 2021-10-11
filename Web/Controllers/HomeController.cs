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
            var homeViewModel = new HomeViewModel
            {
                UserConnected = _userConnected.Entity.GetById(Guid.Parse("F291DCB9-3AA3-4623-A01A-C2F61D39AD23")),
                Items = _item.Entity.GetAll().ToList()
            };

            return View(homeViewModel);
        }
    }
}
