using System;
using System.Collections.Generic;
using System.Text;

namespace Space.Imdb.Bll.Contracts.Models.Imdb.FilterData.MovieService
{
    public class MovieByIdFilterData
    {

        public string Id { get; set; }
        public string Title { get; set; }
        public string FullTitle { get; set; }
        public double ImDbRating { get; set; }
        public string ErrorMessage { get; set; }
    }

}
