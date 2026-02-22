using System.Collections.Generic;
using CateringCo.Models;

namespace CateringCo.ViewModels
{
    public class MenuItemListViewModel
    {
        public List<MenuItem> MenuItems { get; set; } = new();
        public string PageTitle { get; set; } = "MenuItems";
        public int TotalCount { get; set; }
        public string EmptyMessage { get; set; } = "No menu items found.";
    }
}

