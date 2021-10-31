using Space.Imdb.Bll.Contracts.Models.Imdb.FilterData;
using Space.Imdb.Bll.Contracts.Models.Imdb.FilterData.MovieService;
using Space.Imdb.Bll.Contracts.Models.Imdb.Filters;
using System.Threading.Tasks;

namespace Space.Imdb.Bll.Contracts.Interfaces.Service
{
    public interface IImdService
    {
        Task<MoviesByTitleFilterData> SearchMovieByTitle(MoviesByTitleFilter filter);
        Task<MovieByIdFilterData> SearchMovieById(MovieInfoByIdFilter filter);
        Task<MovieWikiByIdFilterData> SearchMovieWikiById(MovieWikiByIdFilter filter);
        Task<MoviePosterByIdFilterData> SearchMoviePosterById(MoviePosterByIdFilter filter);
    }
}
