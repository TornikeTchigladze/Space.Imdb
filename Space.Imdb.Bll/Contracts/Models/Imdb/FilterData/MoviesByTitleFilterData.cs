using System;
using System.Collections.Generic;
using System.Text;

namespace Space.Imdb.Bll.Contracts.Models.Imdb.FilterData
{
    public class MoviesByTitleFilterData
    {
        public string SearchType { get; set; }
        public string Expression { get; set; }

        public List<MoviesByTitleFilterResult> Results { get; set; }

        public string ErrorMessage { get; set; }
    }

    public class MoviesByTitleFilterResult
    {
        public string Id { get; set; }
        public string ResultType { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public enum SearchType
    {
        Title = 1,
        Movie = 2,
        Series = 4,
        Name = 8,
        Episode = 16,
        Company = 32,
        Keyword = 64,
        All = 128
    }
}
