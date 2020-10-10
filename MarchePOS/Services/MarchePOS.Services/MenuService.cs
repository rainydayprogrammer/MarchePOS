using MarchePOS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarchePOS.Services
{
    public class MenuService : IMenuService
    {
        public MenuService()
        {
            MainMenuItems = new List<MenuItem>();
        }

        List<MenuItem> MainMenuItems { get; set; }

        public List<MenuItem> GetMainMenuItems()
        {
            return MainMenuItems;
        }

        public void AddMainMenuItem(MenuItem menuItem)
        {
            MainMenuItems.Add(menuItem);
        }
    }
}
