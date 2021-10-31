using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Space.Imdb.Api.Models.Responses
{
    public class GetMovieWatchListByUserIdResponse
    {
        public int Id { get; set; }
        public string Movie { get; set; }
        public string User { get; set; }
        public DateTime CreateDate { get; set; }
        public string Date { get; set; }
        public bool IsWatched { get; set; }
    }
}
