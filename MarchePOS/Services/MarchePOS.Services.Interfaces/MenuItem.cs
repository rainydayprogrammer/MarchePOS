using System;
using System.Collections.Generic;
using System.Text;

namespace MarchePOS.Services.Interfaces
{
    public class MenuItem
    {
        public string Title { get; set; }
        public string IconName { get; set; }
        public string Description { get; set; }
        public string NavigatePath { get; set; }
    }
}
