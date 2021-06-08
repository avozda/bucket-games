using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bucket_games.Models;

namespace bucket_games.Data
{
    public class bucket_gamesContext : DbContext
    {
        public bucket_gamesContext (DbContextOptions<bucket_gamesContext> options)
            : base(options)
        {
        }

        public DbSet<Hra> Hra { get; set; }
    }
}
