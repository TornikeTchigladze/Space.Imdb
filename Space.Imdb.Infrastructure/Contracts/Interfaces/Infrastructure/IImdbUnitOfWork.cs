using Space.Imdb.DB.Contracts.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Space.Imdb.Infrastructure.Contracts.Interfaces.Services
{
    public interface IImdbUnitOfWork : IUnitOfWork
    {
        IMovieRepository MovieRepository { get; }
        IUsersRepository UsersRepository { get; }
        IWatchListRepository WatchListRepository { get; }
        INotificationsRepository NotificationsRepository { get; }
    }
}
