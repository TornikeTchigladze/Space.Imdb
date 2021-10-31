using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestSharp;
using Space.Imdb.Bll.Contracts.Interfaces.Service;
using Space.Imdb.Bll.Contracts.Models.Imdb.FilterData;
using Space.Imdb.Bll.Contracts.Models.Imdb.FilterData.MovieService;
using Space.Imdb.Bll.Contracts.Models.Imdb.Filters;
using Space.Imdb.Infrastructure.Contracts.Models.Config;
using System;
using System.Threading.Tasks;

namespace Space.Imdb.Bll.Service
{
    public class ImdService : IImdService
    {
        private readonly ImdbConfig _imdbConfig;
        private readonly ILogger<ImdService> _logger;
        public ImdService(IOptions<ImdbConfig> imdbConfig, ILogger<ImdService> logger) 
        {
            _imdbConfig = imdbConfig.Value;
            _logger = logger;
        }

        public async Task<MoviesByTitleFilterData> SearchMovieByTitle(MoviesByTitleFilter filter)
        {
            try
            {
                var client = new RestClient
                {
                    BaseUrl = new Uri($"{_imdbConfig.Url}/en/API/Search/{_imdbConfig.ApiKey}/{filter.Title}")
                };
                var restRequest = new RestRequest
                {
                    Method = Method.GET
                };
                client.Timeout = 5000;
                var response = await client.ExecuteAsync<MoviesByTitleFilterData>(restRequest);
                if (!response.IsSuccessful || response.ResponseStatus != ResponseStatus.Completed)
                {
                    throw new Exception($"SearchByTitle Faild -> IsSuccessful = {response.IsSuccessful} -> ErrorMessage = {response.ErrorMessage} -> ErrorException = {response.ErrorException} -> Content = {response.Content}");

                }

                return response.Data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<MovieByIdFilterData> SearchMovieById(MovieInfoByIdFilter filter)
        {
            try
            {
                var client = new RestClient
                {
                    BaseUrl = new Uri($"{_imdbConfig.Url}/en/API/Title/{_imdbConfig.ApiKey}/{filter.MovieId}")
                };
                var restRequest = new RestRequest
                {
                    Method = Method.GET
                };

                client.Timeout = 5000;
                var response = await client.ExecuteAsync<MovieByIdFilterData>(restRequest);
                if (!response.IsSuccessful || response.ResponseStatus != ResponseStatus.Completed)
                {
                    var errorMessage = $"MovieByIdFilterData Faild -> IsSuccessful = {response.IsSuccessful} -> ErrorMessage = {response.ErrorMessage} -> ErrorException = {response.ErrorException} -> Content = {response.Content}";
                    throw new Exception(errorMessage);
                }

                return response.Data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<MovieWikiByIdFilterData> SearchMovieWikiById(MovieWikiByIdFilter filter)
        {
            try
            {
                var client = new RestClient
                {
                    BaseUrl = new Uri($"{_imdbConfig.Url}/en/API/Wikipedia/{_imdbConfig.ApiKey}/{filter.MovieId}")
                };

                var restRequest = new RestRequest
                {
                    Method = Method.GET
                };

                client.Timeout = 5000;
                var response = await client.ExecuteAsync<MovieWikiByIdFilterData>(restRequest);
                if (!response.IsSuccessful || response.ResponseStatus != ResponseStatus.Completed)
                {
                    var errorMessage = $"Get Movie Poster Faild -> IsSuccessful = {response.IsSuccessful} -> ErrorMessage = {response.ErrorMessage} -> ErrorException = {response.ErrorException} -> Content = {response.Content}";
                    throw new Exception(errorMessage);
                }

                return response.Data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<MoviePosterByIdFilterData> SearchMoviePosterById(MoviePosterByIdFilter filter)
        {
            try
            {
                var client = new RestClient
                {
                    BaseUrl = new Uri($"{_imdbConfig.Url}/en/API/Posters/{_imdbConfig.ApiKey}/{filter.MovieId}")
                };

                var restRequest = new RestRequest
                {
                    Method = Method.GET
                };

                client.Timeout = 5000;
                var response = await client.ExecuteAsync<MoviePosterByIdFilterData>(restRequest);
                if (!response.IsSuccessful || response.ResponseStatus != ResponseStatus.Completed)
                {
                    var errorMessage = $"Get Movie Poster Faild -> IsSuccessful = {response.IsSuccessful} -> ErrorMessage = {response.ErrorMessage} -> ErrorException = {response.ErrorException} -> Content = {response.Content}";
                    throw new Exception(errorMessage);
                }

                return response.Data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
