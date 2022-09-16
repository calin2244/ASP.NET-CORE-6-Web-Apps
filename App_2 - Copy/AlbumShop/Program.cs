using Microsoft.EntityFrameworkCore;
using AlbumShop.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ShopDbContext>(opts => {
    opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:AlbumShopConnection"]);
});

builder.Services.AddScoped<IShopRepository, EFShopRepo>();
//EFShopRepo will be the implementation class for the IShopRepository INTERFACE!!

builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();

app.MapControllerRoute(name: "catpage",
    pattern: "{genre}/Page{prodPage:int}",
    defaults: new {Controller = "Home", action = "Index"}
);

app.MapControllerRoute(name: "page",
    pattern: "Page{prodPage:int}",
    defaults:new {Controller = "Home", action = "Index", prodPage = 1});

app.MapControllerRoute(
    name: "genre",
    pattern: "{genre}/{prodPage:int}",
    defaults: new{Controller = "Home", action = "Index", prodPage = 1}
);

/*app.MapControllerRoute("pagination",
"Albums/Page{prodPage}",
new {Controller = "Home", action = "Index", prodPage = 1});
*/

app.MapControllerRoute(
    name: "pagination",
    pattern: "Albums/Page{prodPage:int}",
    defaults: new{Controller = "Home", action = "Index", prodPage = 1}
);

app.MapControllerRoute(
    name: "home",
    pattern: "Home/Info",
    defaults: new{Controller = "Home", action = "Home"}
);

app.MapDefaultControllerRoute();
app.MapRazorPages();

//seed the database when the app starts running
SeedData.EnsurePopulated(app);

app.Run();

//RESETTING THE DATABASE
//dotnet ef database drop --force --context ShopDbContext