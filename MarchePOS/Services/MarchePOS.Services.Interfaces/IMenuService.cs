using System;
using System.Collections.Generic;
using System.Text;

namespace MarchePOS.Services.Interfaces
{
    public interface IMenuService
    {
        List<MenuItem> GetMainMenuItems();
        void AddMainMenuItem(MenuItem menuItem);
    }
}
