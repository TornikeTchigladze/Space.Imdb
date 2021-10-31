using Microsoft.EntityFrameworkCore;
using Space.Imdb.DB.Contracts.Entities;
using Space.Imdb.DB.Contracts.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Space.Imdb.DB.Repositories
{
    public class NotificationsRepository : Repository<Notifications>, INotificationsRepository
    {
        public NotificationsRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
