using Space.Imdb.Bll.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Space.Imdb.Bll.Contracts.Models.WatchList.FilterData
{
    public class WatchListSaveFilterData
    {
        public WatchListSaveFilterData() 
        {
            Status = WatchListSaveStatuses.Success;
        }
        public WatchListSaveStatuses Status { get; set; }
    }
}
