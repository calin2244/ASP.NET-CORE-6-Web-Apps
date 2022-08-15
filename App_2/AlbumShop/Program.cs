using Microsoft.EntityFrameworkCore;
using AlbumShop.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ShopDbContext>(opts => {
    opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:AlbumShopConnection"]);
});

builder.Services.AddScoped<IShopRepository, EFShopRepo>();

var app = builder.Build();

app.UseStaticFiles();

app.MapDefaultControllerRoute();

app.Run();