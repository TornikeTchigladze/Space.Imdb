using AutoMapper;
using Microsoft.Extensions.Logging;
using Space.Imdb.Bll.Contracts.Enums;
using Space.Imdb.Bll.Contracts.Interfaces.Service;
using Space.Imdb.Bll.Contracts.Models.Imdb.FilterData.MovieService;
using Space.Imdb.Bll.Contracts.Models.Imdb.Filters;
using Space.Imdb.Bll.Contracts.Models.WatchList.Filter;
using Space.Imdb.Bll.Contracts.Models.WatchList.FilterData;
using Space.Imdb.DB.Contracts.Entities;
using Space.Imdb.Infrastructure.Contracts.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space.Imdb.Bll.Service
{
    public class WatchListService : IWatchListService
    {
        private readonly ILogger<WatchListService> _logger;
        private readonly IImdService _imdbService;
        private readonly IImdbUnitOfWork _uow;
        private readonly IMapper _mapper;
        public WatchListService(ILogger<WatchListService> logger, IImdService imdbService, IImdbUnitOfWork uow, IMapper mapper)
        {
            _logger = logger;
            _imdbService = imdbService;
            _uow = uow;
            _mapper = mapper;
        }

        public Task<List<WatchListByUserIdFilterData>> GetWatchListByUserId(WatchListByUserIdFilter filter)
        {
            var result = _uow.WatchListRepository.Filter(u => u.UserId == filter.UserId, includ => includ.Movie, includ => includ.Users, includ => includ.Movie.Posters, includ => includ.Movie.Wikipedia).ToList();
        
            return Task.FromResult(_mapper.Map<List<Watchlist>, List<WatchListByUserIdFilterData>>(result));
        }

        public Task<WatchListMarkedWatchedFIlterData> MarkedWatchListAsWatched(WatchListMarkedWatchedFIlter filter)
        {
            WatchListMarkedWatchedFIlterData response = new WatchListMarkedWatchedFIlterData();
            try
            {
                var movie = _uow.WatchListRepository.Filter(wl => wl.Id == filter.WatchListId).FirstOrDefault();

                if (movie == null)
                {
                    response.Status = WatchListMarkWatchedStatus.CantFindMovie;

                    return Task.FromResult(response);
                }

                movie.IsWatched = true;
                _uow.WatchListRepository.Update(movie);
                _uow.Save();
            }
            catch (Exception ex)
            {
                response.Status = WatchListMarkWatchedStatus.Error;
                _logger.LogError(ex.Message, ex);
            }

            return Task.FromResult(response);
        }

        public Task<WatchListSaveFilterData> SaveWatchList(WatchListSaveFilter filter)
        {
            WatchListSaveFilterData response = new WatchListSaveFilterData();
            try
            {
                var movie = _mapper.Map<Movie>(_imdbService.SearchMovieById(_mapper.Map<MovieInfoByIdFilter>(filter)).Result);
                if (movie == null || string.IsNullOrEmpty(movie.MovieId))
                {
                    response.Status = WatchListSaveStatuses.CantFindMovie;
                    return Task.FromResult(response);
                }

                movie.Posters = _mapper.Map<List<PosterDataItem>, List<MoviePoster>>(_imdbService.SearchMoviePosterById(_mapper.Map<MoviePosterByIdFilter>(filter)).Result.Posters);
                movie.Wikipedia = _mapper.Map<MovieWikiShort>(_imdbService.SearchMovieWikiById(_mapper.Map<MovieWikiByIdFilter>(filter)).Result.PlotShort);
                var user = _uow.UsersRepository.Filter(f => f.Id == filter.UserId).FirstOrDefault();
                var watchList = new Watchlist() { Movie = movie, Users = user };
                if (user == null)
                {
                    response.Status = Contracts.Enums.WatchListSaveStatuses.UserDoesNotExist;
                }

                _uow.WatchListRepository.Create(watchList);
                _uow.Save();
            }
            catch (Exception ex)
            {
                response.Status = Contracts.Enums.WatchListSaveStatuses.Error;
                _logger.LogError(ex.Message, ex);
            }

            return Task.FromResult(response);
        }
    }
}
