using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels;

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
                UserConnected = _userConnected.Entity.GetById(Guid.Parse("BC511D5F-6B39-4CAD-9DCE-7D506EF6E20F")),
                Items = _item.Entity.GetAll().ToList()
            };

            return View(homeViewModel);
        }
    }
}
