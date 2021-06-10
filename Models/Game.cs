using System;
namespace bucket_soldier_games.Models
{
    public class Game
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string ShortDesc  { get; set; }
        public string LongDesc { get; set; }
        public string Img { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public Game()
        {
           
        }
    }
}
