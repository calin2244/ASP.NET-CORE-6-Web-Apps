using Microsoft.EntityFrameworkCore;

namespace AlbumShop.Models{
    public class ShopDbContext : DbContext{
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options){}
        public DbSet<Album> Albums => Set<Album>();
    }
}