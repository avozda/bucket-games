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
                          Title = "Battlefield 6",
                          ShortDesc = "Action FPS shooter with amazing graphics",
                          LongDesc = "Battlefield 6 is set to be the next game in the war-based multiplayer franchise and the first Battlefield game to make a proper next-generation debut on the PS5 and Xbox Series X. ",
                          Img = "https://www.zing.cz/wp-content/uploads/2021/04/BF-1-750x375.jpg",
                          Price = 59.99f,
                          Category = Categories["MultiPlayer"]

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
                        Title = "Dark Souls 3",
                        ShortDesc = "Hardest game you've ever player",
                        LongDesc = "Embrace the gritty experience of an improvised modern-day guerrilla and take down a Dictator and his son to free Yara.",
                        Img = "https://im9.cz/iR/importprodukt-orig/d5e/d5e3b0b607a26b5964787a428d505baa--mmf250x250.jpg",
                        Price = 49.99f,
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