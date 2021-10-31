using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Space.Imdb.Api.Models.Requests;
using Space.Imdb.Api.Models.Responses;
using Space.Imdb.Bll.Contracts.Enums;
using Space.Imdb.Bll.Contracts.Interfaces.Service;
using Space.Imdb.Bll.Contracts.Models.WatchList.Filter;
using Space.Imdb.Bll.Contracts.Models.WatchList.FilterData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Space.Imdb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchListController : Controller
    {
        private readonly IWatchListService _watchListService;
        private readonly IMapper _mapper;

        public WatchListController(IWatchListService watchListService, IMapper mapper)
        {
            _watchListService = watchListService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("SaveMovieInWatchList")]
        public async Task<Response<SaveMovieInWatchListResponse>> SaveMovieInWatchList([FromBody] SaveMovieInWatchListRequest request)
        {
            var response = new Response<SaveMovieInWatchListResponse>();
            response.Data = new SaveMovieInWatchListResponse();
            try
            {
                var result = await _watchListService.SaveWatchList(_mapper.Map<WatchListSaveFilter>(request));
                response.Data.Status = result.Status.ToString();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpGet]
        [Route("GetMovieWatchListByUserId")]
        public async Task<Response<List<GetMovieWatchListByUserIdResponse>>> GetMovieWatchListByUserId([FromQuery] GetMovieWatchListByUserIdRequest request)
        {
            var response = new Response<List<GetMovieWatchListByUserIdResponse>>();
            response.Data = new List<GetMovieWatchListByUserIdResponse>();
            try
            {
                var result = await _watchListService.GetWatchListByUserId(_mapper.Map<WatchListByUserIdFilter>(request));
                response.Data = _mapper.Map<List<WatchListByUserIdFilterData>, List<GetMovieWatchListByUserIdResponse>>(result);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpPost]
        [Route("MarkedMovieAsWatched")]
        public async Task<Response<MarkedMovieAsWatchedResponse>> MarkedMovieAsWatched([FromBody] MarkedMovieAsWatchedRequest request)
        {
            var response = new Response<MarkedMovieAsWatchedResponse>();
            response.Data = new MarkedMovieAsWatchedResponse();
            try
            {
                var result = await _watchListService.MarkedWatchListAsWatched(_mapper.Map<WatchListMarkedWatchedFIlter>(request));
                response.Data.Status = result.Status.ToString();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
