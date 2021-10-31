using System;
using System.Collections.Generic;
using System.Text;

namespace Space.Imdb.Infrastructure.Contracts.Interfaces.Services
{
    public interface IUnitOfWork : IDisposable
    {
        void RegenerateContext();
        void Save();
    }
}
