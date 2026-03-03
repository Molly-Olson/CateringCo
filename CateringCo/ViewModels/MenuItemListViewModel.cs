using System.Collections.Generic;
using CateringCo.Models;
using CateringCo.DTOs;

namespace CateringCo.ViewModels
{
    public class MenuItemListViewModel
    {
        public List<MenuListItemDto> MenuItems { get; set; } = new();
        public string PageTitle { get; set; } = "Menu Items";
        public int TotalCount { get; set; }
        public string EmptyMessage { get; set; } = "No menu items found.";
    }
}

