using CateringCo.Services;
using CateringCo.Tests.TestHelpers;
using CateringCo.Models;
using Xunit;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace CateringCo.Tests.Services
{
    public class CateringServiceTest
    {
        [Fact]
        public async Task GetAllAsync_FiltersOutMenuItems_WithEmptyDescription()
        {
            var dbName = "FiltersEmptyDescription";
            using var context = CateringCoContextFactory.Create(dbName);

            context.MenuItems.AddRange(
                new MenuItem { Name = "Pea Pesto Pasta", Description = "Sweatpea pesto with nutritional yeast and hemp hearts over bowtie pasta", Price = 22 },
                new MenuItem { Name = "Asparagus Tacos", Price = 18 },
                new MenuItem { Name = "Banana Pancakes", Price = 15 }
                );
            await context.SaveChangesAsync();
            var service = new MenuService(context);
            var results = await service.GetAllAsync();

            Assert.Single(results);
            Assert.Equal("Pea Pesto Pasta", results[0].Description);
        }

        [Fact]
        public async Task GetAllAsync_OrdersMenuItem_ByPrice()
        {
            var dbName = "OrdersByPrice";
            using var context = CateringCoContextFactory.Create(dbName);
            context.MenuItems.AddRange(
                new MenuItem { Name = "Pea Pesto Pasta", Description = "Sweatpea pesto with nutritional yeast and hemp hearts over bowtie pasta", Price = 22 },
                new MenuItem { Name = "Asparagus Tacos", Price = 18 },
                new MenuItem { Name = "Banana Pancakes", Price = 15 }
                );
            await context.SaveChangesAsync();
            var service = new MenuService(context);
            var results = await service.GetAllAsync();

            Assert.Equal(15, results[0].Price);
            Assert.Equal(18, results[1].Price);
            Assert.Equal(22, results[3].Price);

        }
        [Fact]
        public async Task GetAllAsync_FiltersOutLocations_WithEmptyAddress()
        {
            var dbName = "FiltersEmptyAddress";
            using var context = CateringCoContextFactory.Create(dbName);

            context.Locations.AddRange(
                 new Locations { Name = "Downtown", Address = "123 Main St", Phone = "555-123-4567" },
                 new Locations { Name = "Uptown", Phone = "555-987-3543" },
                 new Locations { Name = "Suburbs", Address = "789 Oak St", Phone = "555-222-4444" }
                );
            await context.SaveChangesAsync();
            var service = new LocationsService(context);
            var results = await service.GetAllAsync();

            Assert.Single(results);
            Assert.Equal("Downtown", results[0].Address);
            Assert.Equal("Suburbs", results[1].Address);
        }
    }
}
