using System;
using System.Collections.Generic;
using System.Text;

namespace Space.Imdb.DB.Contracts.Entities
{
    public class MovieWikiShort
    {
        public int Id { get; set; }
        public string PlainText { get; set; }
        public string Html { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
