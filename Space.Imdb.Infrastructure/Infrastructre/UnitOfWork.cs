using Microsoft.EntityFrameworkCore;
using Space.Imdb.Infrastructure.Contracts.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Space.Imdb.Infrastructure.Infrastructre
{
    public abstract class UnitOfWork<TContext> : IUnitOfWork
            where TContext : DbContext
    {
        private TContext _dbContext;
        private readonly IDbContextFactory<TContext> _dbContextFactory;

        protected UnitOfWork(IDbContextFactory<TContext> dbContextFactory)
            : this(dbContextFactory.CreateDbContext())
        {
            _dbContextFactory = dbContextFactory;
        }


        protected UnitOfWork(TContext context)
        {
            _dbContext = context;
        }

        public virtual TContext Context
        {
            get
            {
                return _dbContext;
            }
        }

        public void RegenerateContext()
        {
            if (_dbContext != null)
            {
                Save();
            }
            _dbContext = _dbContextFactory.CreateDbContext();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        #region " Dispose "

        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    if (_dbContext != null)
                    {
                        _dbContext.Dispose();
                    }
                }
            }
            _disposedValue = true;
        }


        #region " IDisposable Support "

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        #endregion " IDisposable Support "

        #endregion " Dispose "
    }
}
