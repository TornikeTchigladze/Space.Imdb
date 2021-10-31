using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Space.Imdb.Api.Models.Requests
{
    public class GetMovieWatchListByUserIdRequest
    {
        public int UserId { get; set; }
    }
}
