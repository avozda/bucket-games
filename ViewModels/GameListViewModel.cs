using System;
using System.Collections.Generic;
using bucket_soldier_games.Models;

namespace bucket_soldier_games.ViewModels
{
    public class GameListViewModel
    {
        public IEnumerable<Game> Games { get; set; }
        public string CurrentCategory { get; set; }
    }
}
