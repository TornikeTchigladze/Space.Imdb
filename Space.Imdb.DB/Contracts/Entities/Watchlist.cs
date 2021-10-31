using System;
using System.Collections.Generic;
using System.Text;

namespace Space.Imdb.DB.Contracts.Entities
{
    public class Watchlist
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public Users Users { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Date { get; set; }
        public bool IsWatched { get; set; }
        public List<Notifications> Notifications { get; set; } 
    }
}
