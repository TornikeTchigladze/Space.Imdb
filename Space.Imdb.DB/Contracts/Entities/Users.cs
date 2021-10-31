using System;
using System.Collections.Generic;
using System.Text;

namespace Space.Imdb.DB.Contracts.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<Watchlist> Watchlist { get; set; }
    }
}
