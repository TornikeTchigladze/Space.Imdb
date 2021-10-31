using Space.Imdb.Bll.Contracts.Models.WatchList.Filter;
using Space.Imdb.Bll.Contracts.Models.WatchList.FilterData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Space.Imdb.Bll.Contracts.Interfaces.Service
{
    public interface IWatchListService
    {
        public Task<WatchListSaveFilterData> SaveWatchList(WatchListSaveFilter filter);

        public Task<List<WatchListByUserIdFilterData>> GetWatchListByUserId(WatchListByUserIdFilter filter);

        public Task<WatchListMarkedWatchedFIlterData> MarkedWatchListAsWatched(WatchListMarkedWatchedFIlter filter);
    }
}
