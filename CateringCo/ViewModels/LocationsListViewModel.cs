using System.Collections.Generic;
using CateringCo.Models;
using CateringCo.DTOs;

namespace CateringCo.ViewModels
{
    public class LocationsListViewModel
    {
        public List<LocationListItemDto> Locations { get; set; } = new();
        public string PageTitle { get; set; } = "";
        public string SearchTerm { get; set; } = "";
        public int TotalCount { get; set; }
        public string EmptyMessage { get; set; } = "No locations found.";
    }
}
