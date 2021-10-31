using System;
using System.Collections.Generic;
using System.Text;

namespace Space.Imdb.Bll.Contracts.Models.WatchList.Filter
{
    public class WatchListSaveFilter
    {
        public int UserId { get; set; }
        public string MovieId { get; set; }
    }
}
