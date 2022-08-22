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
                        Price = 29.95m,
                        Genre = "Hip-Hop/Rap",
                        RecordLabel = "@2019 WUNDERWORLD",
                        SpotifyEmbed = "https://open.spotify.com/embed/album/2NDlOOZNBvq6B26feV4gJc?utm_source=generator",
                        CoverLink = "https://66.media.tumblr.com/f6febb9107dd19dc9a51c76760efefa5/tumblr_inline_pq4graX2XT1s9on4d_540.png"
                    },
                    new Album{
                        AlbumName = "Believe In Me, Who Believes In You",
                        ArtistName = "Aries",
                        Description = "Desperado is a placeholder.",
                        RecordType = "CD",
                        Rating = 4,
                        Price = 34.95m,
                        Genre = "Pop/Punk",
                        RecordLabel = "@2021 WUNDERWORLD",
                        SpotifyEmbed = "https://open.spotify.com/embed/album/1eLp5qe0nJkOb3rzqnbme0?utm_source=generator",
                        CoverLink = "https://i.scdn.co/image/ab67616d0000b2734bc2f112800b4f738cc3fe1a"
                    },
                    new Album{
                        AlbumName = "Red(Taylor's Version)",
                        ArtistName = "Taylor Swift",
                        Description = "Revamped version of the Red album",
                        RecordType = "Vinyl(2 Vinyls)",
                        Rating = 5,
                        Price = 55.95m,
                        Genre = "Country Music/Pop",
                        RecordLabel = "@2021 Taylor Swift",
                        SpotifyEmbed = "https://open.spotify.com/embed/album/6kZ42qRrzov54LcAk4onW9?utm_source=generator",
                        CoverLink = "https://images.genius.com/7809d535eef0145a98d1ef1d5fbe4391.1000x1000x1.jpg"
                    },
                    new Album{
                        AlbumName = "The Life Of Pi'erre 4",
                        ArtistName = "Pi'erre Bourne",
                        Description = "The last but one installment inspired by Kanye's Life of Pablo.",
                        RecordType = "CD",
                        Rating = 4,
                        Price = 20m,
                        Genre = "Hip-Hop/Rap",
                        RecordLabel = "@2019 WUNDERWORLD",
                        SpotifyEmbed = "https://open.spotify.com/embed/album/0agALBMd2a8cnpbpukTg03?utm_source=generator",
                        CoverLink = "https://images.genius.com/7438d273cb5ef25403610728b10e8562.640x640x1.jpg"
                    },
                    new Album{
                        AlbumName = "Die Lit",
                        ArtistName = "Playboi Carti",
                        Description = "Incredible album. Very fun and intoxicating.",
                        RecordType = "Vinyl",
                        Rating = 5,
                        Price = 39.95m,
                        Genre = "Hip-Hop/Rap",
                        RecordLabel = "@2019 WUNDERWORLD",
                        SpotifyEmbed = "https://open.spotify.com/embed/album/7dAm8ShwJLFm9SaJ6Yc58O?utm_source=generator&theme=0",
                        CoverLink = "https://images.genius.com/d3648154d6d90501b1fd53f863ebd4da.933x1000x1.jpg"   
                    },
                    new Album{
                        AlbumName = "Luv Is Rage 2",
                        ArtistName = "Lil Uzi Vert",
                        Description = "Iconic Trap album.",
                        RecordType = "Vinyl",
                        Rating = 4,
                        Price = 34.95m,
                        Genre = "Hip-Hop/Rap",
                        RecordLabel = "@2019 WUNDERWORLD",
                        SpotifyEmbed = "https://open.spotify.com/embed/album/0zicd2mBV8HTzSubByj4vP?utm_source=generator",
                        CoverLink = "https://images.genius.com/50af11dfe454a4aa20544f19b2dd0791.1000x1000x1.png"
                    },
                    new Album{
                        AlbumName = "Donda",
                        ArtistName = "Kanye West",
                        Description = "Heart feeling album.",
                        RecordType = "Vinyl/CD",
                        Rating = 4.5,
                        Price = 44.95m,
                        Genre = "R&B/Soul",
                        RecordLabel = "@2019 WUNDERWORLD",
                        SpotifyEmbed = "https://open.spotify.com/embed/album/5CnpZV3q5BcESefcB3WJmz?utm_source=generator&theme=0",
                        CoverLink = "https://images.genius.com/e073a37e5ffcf442900c023bf4349036.1000x1000x1.png"
                    },
                    new Album{
                        AlbumName = "Folklore",
                        ArtistName = "Taylor Swift",
                        Description = " Influenced by loneliness during the quarantine, Swift explores themes of escapism, empathy, romanticism, and nostalgia in the album, through a set of characters, fictional narratives, and story arcs.",
                        RecordType = "Vinyl/CD",
                        Rating = 5,
                        Price = 44.95m,
                        Genre = "Alternative/Indie",
                        RecordLabel = "@2020 Taylor Swift",
                        SpotifyEmbed = "https://open.spotify.com/embed/album/1pzvBxYgT6OVwJLtHkrdQK?utm_source=generator",
                        CoverLink = "https://images.genius.com/1509fab32e174cf85ecf7194bf260a93.1000x1000x1.png"
                    },
                    new Album{
                        AlbumName = "shut the f**k up talking to me",
                        ArtistName = "Zack Fox",
                        Description = "A comedian that actually crafter a great, fun album.",
                        RecordType = "CD",
                        Rating = 4.5,
                        Price = 14.95m,
                        Genre = "Hip-Hop/Rap",
                        RecordLabel = "@2021 Parasang",
                        SpotifyEmbed = "https://open.spotify.com/embed/album/1tiD0UGetoA3qTkJN3Thdv?utm_source=generator",
                        CoverLink = "https://images.genius.com/58e168e52bbb1ea1acaf2b951870a242.1000x1000x1.png"
                    },
                    new Album{
                        AlbumName = "GERM HAS A DEATHWISH",
                        ArtistName = "Germ",
                        Description = "Germ has a Deathwish is a play on the 2008 skate movie “Baker has a Deathwish” even using the same font.",
                        RecordType = "CD",
                        Rating = 4,
                        Price = 24.95m,
                        Genre = "Hip-Hop/Rap",
                        RecordLabel = "@2019 G59 Records",
                        SpotifyEmbed = "https://open.spotify.com/embed/album/5eWTQHm7yXnuxlHpG9Lf23?utm_source=generator",
                        CoverLink = "https://images.genius.com/5d2aea676cdbb531f7e16477496bd9f5.1000x1000x1.jpg"
                    }
                );
                ctx.SaveChanges();
            }
        }
    }
}