using Microsoft.EntityFrameworkCore;
using Space.Imdb.DB.Contracts.Entities;
using Space.Imdb.DB.Contracts.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Space.Imdb.DB.Repositories
{
    public class WatchListRepository : Repository<Watchlist>, IWatchListRepository
    {
        public WatchListRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
