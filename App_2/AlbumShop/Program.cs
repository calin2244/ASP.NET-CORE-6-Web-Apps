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

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute("pagination",
    "Albums/Page{prodPage}", new {Controller = "Home", action = "Index"}
);

app.MapDefaultControllerRoute();

//seed the database when the app starts running
SeedData.EnsurePopulated(app);

app.Run();

//RESETTING THE DATABASE
//dotnet ef database drop --force --context ShopDbContext