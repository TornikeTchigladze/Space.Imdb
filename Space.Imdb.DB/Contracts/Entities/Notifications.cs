using System;
using System.Collections.Generic;
using System.Text;

namespace Space.Imdb.DB.Contracts.Entities
{
    public class Notifications
    {
        public int Id { get; set; }
        public int WatchListId { get; set; }
        public Watchlist Watchlist { get; set; }
        public DateTime CreateDate { get; set; }
        public string Date { get; set; }
    }
}
