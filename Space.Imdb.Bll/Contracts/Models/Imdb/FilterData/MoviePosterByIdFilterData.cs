﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Space.Imdb.Bll.Contracts.Models.Imdb.FilterData.MovieService
{

    public class MoviePosterByIdFilterData
    {
        public string IMDbId { get; set; }
        public string Title { get; set; }
        public string FullTitle { get; set; }
        public string Type { set; get; }
        public string Year { set; get; }
        public List<PosterDataItem> Posters { get; set; }
        public List<PosterDataItem> Backdors { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class PosterDataItem
    {
        public string Id { get; set; }
        public string Link { get; set; }
        public double AspectRatio { get; set; }
        public string Language { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
