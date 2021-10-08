using Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class HomeViewModel
    {
        public User UserConnected { get; set; }
        public List<Item> Items { get; set; }
    }
}
