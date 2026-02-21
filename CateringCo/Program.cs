using CateringCo.Models;
using Microsoft.EntityFrameworkCore;

namespace CateringCo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<CateringCoContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("CateringCoConnection")));

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var db= scope.ServiceProvider.GetRequiredService<CateringCoContext>();
                if (!db.MenuItems.Any())
                {
                    db.MenuItems.AddRange(
                        new MenuItem { Name = "Chicken Alfredo", Description = "Creamy pasta with grilled chicken", Price = 12.99m },
                        new MenuItem { Name = "Beef Stroganoff", Description = "Tender beef in a rich mushroom sauce", Price = 14.99m },
                        new MenuItem { Name = "Vegetable Stir Fry", Description = "Mixed vegetables sautéed in a savory sauce", Price = 10.99m }
                    );
                    db.SaveChanges();
                }
                    if (!db.Locations.Any())
                    {
                        db.Locations.AddRange(
                            new Locations { Name = "Downtown", Address = "123 Main St", Phone = "555-123-4567" },
                            new Locations { Name = "Uptown", Address = "456 Elm St", Phone = "555-987-3543" },
                            new Locations { Name = "Suburbs", Address = "789 Oak St", Phone = "555-222-4444" }
                        );
                        db.SaveChanges();
                    }
                }

                // Configure the HTTP request pipeline.
                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Home/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
