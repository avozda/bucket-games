using System;
using System.Collections.Generic;
using bucket_soldier_games.Models;

namespace bucket_soldier_games.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
