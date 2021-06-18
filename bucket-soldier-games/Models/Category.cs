using System;
using System.Collections.Generic;

namespace bucket_soldier_games.Models
{
    public class Category
    {

        public int id { get; set; }
        public string CategoryName { get; set; }
        public string desc { get; set; }
        public List<Game> Games { get; set; }

        public Category()
        {
        }
    }
}
