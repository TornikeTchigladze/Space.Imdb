using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Space.Imdb.Bll.Contracts.Interfaces.Service
{
    public interface INotificationsService
    {
        Task Send();
    }
}
