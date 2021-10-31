using Space.Imdb.DB.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Space.Imdb.Bll.Contracts.Models.WatchList.FilterData
{
    public class WatchListByUserIdFilterData
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public Users Users { get; set; }
        public DateTime CreateDate { get; set; }
        public string Date { get; set; }
        public bool IsWatched { get; set; }
    }
}
