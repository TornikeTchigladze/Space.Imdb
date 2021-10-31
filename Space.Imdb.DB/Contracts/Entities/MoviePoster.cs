using System;
using System.Collections.Generic;
using System.Text;

namespace Space.Imdb.DB.Contracts.Entities
{
    public class MoviePoster
    {
        public int Id { get; set; }
        public string Poster { get; set; }
        public string Link { get; set; }
        public double AspectRatio { get; set; }
        public string Language { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
