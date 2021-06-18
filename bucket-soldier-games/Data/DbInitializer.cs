using bucket_soldier_games.Data;
using bucket_soldier_games.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bucket_soldier_games.Data
{
    public class DbInitializer
    {
        public static void Seed(IServiceProvider applicationBuilder)
        {
            ApplicationDbContext context =
                applicationBuilder.GetRequiredService<ApplicationDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }


        

            if (!context.Games.Any())
            {
                context.AddRange
                (
                      new Game
                      {
                          Title = "Battlefield 5",
                          ShortDesc = "Action FPS shooter with amazing graphics",
                          LongDesc = "Battlefield 5 is set to be the next game in the war-based multiplayer franchise and the first Battlefield game to make a proper next-generation debut on the PS5 and Xbox Series X. ",
                          Img = "https://im9.cz/iR/importprodukt-orig/839/839a0718612c527ff54922a7b13596f3.jpg",
                          Price = 59.99f,
                          Category = Categories["MultiPlayer"]

                      },
                     new Game
                    {
                        Title = "Dark Souls 3",
                        ShortDesc = "Hardest game you've ever played ",
                        LongDesc = "Embrace the gritty experience of an improvised modern-day guerrilla and take down a Dictator and his son to free Yara.",
                        Img = "https://www.gamemax.cz/files/thumbs/mod_eshop/produkty/dark-souls-iii-the-fire-fades-edition-goty-ps4-40037.761696527.jpg",
                        Price = 49.99f,
                        Category = Categories["SinglePlayer"]

                    },
                    new Game
                    {
                    Title = "Far Cry 6",
                    ShortDesc = "New game from popular series Far Cry",
                    LongDesc = "Embrace the gritty experience of an improvised modern-day guerrilla and take down a Dictator and his son to free Yara.",
                       Img = "https://iczc.cz/bbalerlplojdbbotdq1elt56qb-1_1/obrazek",
                    Price = 49.99f,
                      Category = Categories["SinglePlayer"]
                               }, new Game
                               {
                                   Title = "Witcher 3",
                                   ShortDesc = "The sword of destiny has two blades. You are one of them.",
                                   LongDesc = "You are Geralt from Rivia. Everywhere you look, the cities and settlements of the Northern Kingdoms are compared to the country by an army that does not come from this world. The army, known as the Wild Hunt, leaves behind only a blood-soaked trail of destruction.",
                                   Img = "https://cdn.konzoleahry.cz/images/0/dcdd3281c122ea7b/2/ps4-the-witcher-3-wild-hunt-cz.jpg",
                                   Price = 49.99f,
                                   Category = Categories["SinglePlayer"]

                               },
                new Game
                {
                    Title = "BIOMUTANT",
                    ShortDesc = "BIOMUTANT is a post-apocalyptic Kung-Fu RPG",
                    LongDesc = "BIOMUTANT is a post-apocalyptic Kung-Fu RPG fable in the open world with a unique combat system that allows you to combine contact combat, shooting and action skills of mutants.",
                    Img = "https://www.spelochsant.se//uploads/images/products/315678.jpg",
                    Price = 59.99f,
                    Category = Categories["SinglePlayer"]

                },
                new Game
                {
                    Title = "Resident Evil Village",
                    ShortDesc = "The next generation of survival horror rises in the form of Resident Evil Village",
                    LongDesc = "The eighth major entry in the Resident Evil series. With ultra-realistic graphics powered by the RE Engine, fight for survival as danger lurks around every corner. Set a few years after the horrifying events in the critically acclaimed Resident Evil 7 biohazard, the all-new storyline begins with Ethan Winters and his wife Mia living peacefully in a new location, free from their past nightmares.",
                    Img = "https://www.herni-svet.cz/wareImages/122/5/122526_or.jpg",
                    Price = 59.99f,
                    Category = Categories["SinglePlayer"]

                },
                new Game
                {
                    Title = "Borderlands 2",
                    ShortDesc = "Borderlands 2 furthers the distinct blending of First Person Shooter.",
                    LongDesc = "Team up with up to three other players for four-player online goodness or go old-school with two-player split-screen couch sharing mayhem as you spend hours leveling up your character and equipping them with one of the millions of badass weapons.",
                    Img = "https://cdn.konzoleahry.cz/images/0/e5428b4e61b3183f/2/ps4-borderlands-the-handsome-collection.jpg",
                    Price = 19.99f,
                    Category = Categories["MultiPlayer"]

                },
                new Game
                {
                    Title = "Call of Duty Black Ops Cold War",
                    ShortDesc = "The conical Black Ops series returns in a brand new form of the next generation as Call of Duty: Black Ops Cold War",
                    LongDesc = "In addition to the campaign, Black Ops Cold War provides the next generation of multiplayer combat and a whole new zombie experience. In addition, Black Ops Cold War will include cross-game crossplay and crossplay support for all players playing together.",
                    Img = "https://i.cdn.nrholding.net/52139931/550/550",
                    Price = 59.99f,
                    Category = Categories["MultiPlayer"]

                },
                new Game
                {
                    Title = "FIFA 21",
                    ShortDesc = "FIFA 21 is a football simulation video game published by Electronic Arts as part of the FIFA series",
                    LongDesc = "FIFA 21 is a controversial title that will delight ardent fans of the series longing for a more aggressive approach, but is also a disappointment for the occasional player, as it brings a minimum of changes compared to the previous episode, which it probably notices only marginally, which is very little at full price.",
                    Img = "https://d25-a.sdn.cz/d_25/c_img_QM_Gz/NcUfJy.jpeg",
                    Price = 59.99f,
                    Category = Categories["MultiPlayer"]

                },
                new Game
                {
                    Title = "Lego Star Wars: The Skywalker Saga",
                    ShortDesc = "Lego Star Wars: The Skywalker Saga is an upcoming Lego-themed action adventure",
                    LongDesc = "In LEGO® Star Wars ™: The Skywalker Saga, the whole galaxy will be at your feet! Go through all nine Star Wars saga movies in a brand new and completely unique LEGO video game. Enjoy fun adventures, eccentric humor and the opportunity to immerse yourself freely and fully in the world of Star Wars like never before.",
                    Img = "https://www.jrc.cz/api/File/46275/download?format=jpg",
                    Price = 65.99f,
                    Category = Categories["SinglePlayer"]

                },
                new Game
                {
                    Title = "Red Dead Redemption 2",
                    ShortDesc = "Red Dead Redemption 2 is a western-themed action adventure from 2018, developed and published by Rockstar Games.",
                    LongDesc = "America, 1899. The end of the Wild West era has begun. After a robbery goes badly wrong in the western town of Blackwater, Arthur Morgan and the Van der Linde gang are forced to flee. With federal agents and the best bounty hunters in the nation massing on their heels, the gang must rob, steal and fight their way across the rugged heartland of America in order to survive. As deepening internal divisions threaten to tear the gang apart, Arthur must make a choice between his own ideals and loyalty to the gang who raised him.",
                    Img = "https://www.kuma.cz/images/9103082.jpg",
                    Price = 49.99f,
                    Category = Categories["SinglePlayer"]

                },
                new Game
                {
                    Title = "Dark Souls Remastered",
                    ShortDesc = "Then, there was fire. Re-experience the critically acclaimed, genre-defining game that started it all.",
                    LongDesc = "Then, there was fire. Re-experience the critically acclaimed, genre-defining game that started it all. Beautifully remastered, return to Lordran in stunning high-definition detail running at 60fps. Dark Souls Remastered includes the main game plus the Artorias of the Abyss DLC.",
                    Img = "https://images-na.ssl-images-amazon.com/images/I/81MJwos2HyL._SX425_.jpg",
                    Price = 39.99f,
                    Category = Categories["SinglePlayer"]

                }

                );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                      new Category { CategoryName = "SinglePlayer", desc = "Games for one player" },
                         new Category { CategoryName = "MultiPlayer", desc = "Games for multiple players" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }

                return categories;
            }
        }
    }
}