using Microsoft.EntityFrameworkCore;

namespace AlbumShop.Models{
    
    //Created this class to populate the database and provide some sample data
    public static class SeedData{
        public static void EnsurePopulated(IApplicationBuilder app){
            ShopDbContext ctx = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ShopDbContext>();
            if(ctx.Database.GetPendingMigrations().Any()){
                ctx.Database.Migrate();
            }

            if(!ctx.Albums.Any()){
                ctx.Albums.AddRange(
                    new Album {
                        AlbumName = "Welcome Home",
                        ArtistName = "Aries",
                        Description = "Life changing album.",
                        RecordType = "Vinyl/CD",
                        Rating = 5,
                        Price = 29.95m
                    },
                    new Album{
                        AlbumName = "BIM, WBIY",
                        ArtistName = "Aries",
                        Description = "Desperado is a placeholder.",
                        RecordType = "CD",
                        Rating = 4,
                        Price = 34.95m
                    },
                    new Album{
                        AlbumName = "Red(Taylor's Version)",
                        ArtistName = "Taylor Swift",
                        Description = "Revamped version of the Red album",
                        RecordType = "Vinyl(2 Vinyls)",
                        Rating = 5,
                        Price = 55.95m
                    },
                    new Album{
                        AlbumName = "The Life Of Pi'erre 4",
                        ArtistName = "Pi'erre Bourne",
                        Description = "The last but one installment inspire by Kanye's Life of Pablo.",
                        RecordType = "CD",
                        Rating = 4,
                        Price = 20m
                    },
                    new Album{
                        AlbumName = "Die Lit",
                        ArtistName = "Playboi Carti",
                        Description = "Incredible album. Very fun and intoxicating.",
                        RecordType = "Vinyl",
                        Rating = 5,
                        Price = 39.95m
                    },
                    new Album{
                        AlbumName = "Luv Is Rage 2",
                        ArtistName = "Lil Uzi Vert",
                        Description = "Iconic Trap album.",
                        RecordType = "Vinyl",
                        Rating = 4,
                        Price = 34.95m
                    },
                    new Album{
                        AlbumName = "Donda",
                        ArtistName = "Kanye West",
                        Description = "Heart feeling album.",
                        Rating = 4.5,
                        Price = 44.95m
                    }
                );
                ctx.SaveChanges();
            }
        }
    }
}