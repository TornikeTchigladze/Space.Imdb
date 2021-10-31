using System;
using System.Collections.Generic;
using System.Text;

namespace Space.Imdb.DB.Contracts.Entities
{
    public class Movie
    {
        public Movie()
        {
            Posters = new List<MoviePoster>();
        }

        public int Id { get; set; }
        public string MovieId { get; set; }
        public string Title { get; set; }
        public string FullTitle { get; set; }
        public double ImDbRating { get; set; }
        public List<MoviePoster> Posters { get; set; }
        public MovieWikiShort Wikipedia { get; set; }
        public List<Watchlist> Watchlist { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
