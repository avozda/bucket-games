using System;
using System.Collections.Generic;
using System.Linq;
using bucket_soldier_games.Data;
using bucket_soldier_games.Interfaces;
using bucket_soldier_games.Models;
using Microsoft.EntityFrameworkCore;

namespace bucket_soldier_games.Repositories
{
    public class GameRepository:IGameRepository
    {

        private readonly ApplicationDbContext _appDbContext;
        public GameRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //public IEnumerable<Game> Games => _appDbContext.Games.Include(c => c.Category);

        IEnumerable<Game> IGameRepository.Games { get {
                return _appDbContext.Games.Include(c => c.Category);
            }}

        public Game GetGameById(int gameId) => _appDbContext.Games.FirstOrDefault(p => p.id == gameId);
    }
}
