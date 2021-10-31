using Microsoft.EntityFrameworkCore;
using Space.Imdb.DB.Contracts.Interfaces.Repositories;
using Space.Imdb.DB.Repositories;
using Space.Imdb.Infrastructure.Contracts.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Space.Imdb.Infrastructure.Infrastructre
{
    public class ImdbUnitOfWork : UnitOfWork<ImdbMovieContext>, IImdbUnitOfWork
    {
        private IMovieRepository _movieRepository;
        private IUsersRepository _usersRepository;
        private IWatchListRepository _watchListRepository;
        private INotificationsRepository _notificationsRepository;

        public ImdbUnitOfWork(IDbContextFactory<ImdbMovieContext> contextFactory) : base(contextFactory)
        {

        }

        public IMovieRepository MovieRepository
        {
            get { return _movieRepository = _movieRepository ?? new MovieRepository(Context); }
        }

        public IUsersRepository UsersRepository
        {
            get { return _usersRepository = _usersRepository ?? new UsersRepository(Context); }
        }

        public IWatchListRepository WatchListRepository
        {
            get { return _watchListRepository = _watchListRepository ?? new WatchListRepository(Context); }
        }

        public INotificationsRepository NotificationsRepository
        {
            get { return _notificationsRepository = _notificationsRepository ?? new NotificationsRepository(Context); }
        }
    }
}
