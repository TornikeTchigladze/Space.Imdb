using Microsoft.EntityFrameworkCore;
using Space.Imdb.DB.Contracts.Entities;
using Space.Imdb.DB.Contracts.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Space.Imdb.DB.Repositories
{
    public class UsersRepository : Repository<Users>, IUsersRepository
    {
        public UsersRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
