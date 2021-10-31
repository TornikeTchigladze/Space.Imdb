using System;
using System.Collections.Generic;
using System.Text;

namespace Space.Imdb.Bll.Contracts.Enums
{
    public enum WatchListMarkWatchedStatus
    {
        Success = 1,
        CantFindMovie = -2,
        Error = -3
    }
}
