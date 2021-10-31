using System;
using System.Collections.Generic;
using System.Text;

namespace Space.Imdb.Bll.Contracts.Enums
{
    public enum WatchListSaveStatuses
    {
        Success = 1,
        UserDoesNotExist = -1,
        CantFindMovie = -2,
        Error = -3
    }
}
