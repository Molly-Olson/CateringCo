using CateringCo;
using CateringCo.Models;
using CateringCo.Services;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<CateringCoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CateringCoConnection")));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<CateringCoContext>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<CateringCoContext>()
.AddDefaultTokenProviders();

builder.Services.AddTransient<IEmailSender, DevEmailSender>();

// Week Seven
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "CateringCo API", Version = "v1" });
    c.DocInclusionPredicate((docName, apiDesc) =>
    apiDesc.RelativePath != null &&
    apiDesc.RelativePath.StartsWith("api/", StringComparison.OrdinalIgnoreCase));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // app.UseExceptionHandler("/Home/Error");  **Week Seven Update
    app.UseSwagger();
    app.UseSwaggerUI();
}



   // await db.SaveChangesAsync();

   
// ---------------------------------------------
// Configure HTTP Pipeline
// ---------------------------------------------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();


// ---------------------------------------------
// Seed Data + Identity
// ---------------------------------------------
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CateringCoContext>();

    //var services = scope.ServiceProvider;
    //var db = services.GetRequiredService<CateringCoContext>();
    //var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    //var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

    // Seed Menu Items
    if (!db.MenuItems.Any())
    {
        db.MenuItems.AddRange(
            new MenuItem { Name = "Chicken Alfredo", Description = "Creamy pasta with grilled chicken", Price = 12.99m },
            new MenuItem { Name = "Beef Stroganoff", Description = "Tender beef in a rich mushroom sauce", Price = 14.99m },
            new MenuItem { Name = "Vegetable Stir Fry", Description = "Mixed vegetables saut�ed in a savory sauce", Price = 10.99m }
        );
        db.SaveChanges();
    }

    // Seed Locations
    if (!db.Locations.Any())
    {
        db.Locations.AddRange(
            new Locations { Name = "Downtown", Address = "123 Main St", Phone = "555-123-4567" },
            new Locations { Name = "Uptown", Address = "456 Elm St", Phone = "555-987-3543" },
            new Locations { Name = "Suburbs", Address = "789 Oak St", Phone = "555-222-4444" }
        );
        db.SaveChanges();
    }
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    var adminEmail = "admin@CateringCo.com";
    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        adminUser = new IdentityUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            EmailConfirmed = true
        };
        await userManager.CreateAsync(adminUser, "P@ssw0rd!");
    }
    if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
    {
        await userManager.AddToRoleAsync(adminUser, "Admin");
    }
}

    app.Run();
