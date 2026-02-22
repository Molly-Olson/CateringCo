using System.Collections.Generic;
using CateringCo.Models;

namespace CateringCo.ViewModels
{
    public class LocationsListViewModel
    {
        public List<Locations> Locations { get; set; } = new();
        public string SearchTerm { get; set; } = "";
        public int TotalCount { get; set; }
        public string EmptyMessage { get; set; } = "No locations found.";
    }
}
