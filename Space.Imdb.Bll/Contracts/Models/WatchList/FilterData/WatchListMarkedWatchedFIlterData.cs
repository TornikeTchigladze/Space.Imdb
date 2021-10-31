using Space.Imdb.Bll.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Space.Imdb.Bll.Contracts.Models.WatchList.FilterData
{
    public class WatchListMarkedWatchedFIlterData
    {
        public WatchListMarkedWatchedFIlterData() 
        {
            Status = WatchListMarkWatchedStatus.Success;
        }
        public WatchListMarkWatchedStatus Status { get; set; }
    }
}
