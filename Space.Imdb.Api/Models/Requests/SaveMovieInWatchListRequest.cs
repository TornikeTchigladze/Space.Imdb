using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Space.Imdb.Api.Models.Requests
{
    public class SaveMovieInWatchListRequest
    {
        public string MovieId { get; set; }
        public int UserId { get; set; }
    }
}
