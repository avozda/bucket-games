using System;
using System.Collections.Generic;
using bucket_soldier_games.Data;
using bucket_soldier_games.Interfaces;
using bucket_soldier_games.Models;

namespace bucket_soldier_games.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public CategoryRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Category> Categories => _appDbContext.Categories;
    }
}