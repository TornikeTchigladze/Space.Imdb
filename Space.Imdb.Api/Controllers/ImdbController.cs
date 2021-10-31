using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Space.Imdb.Api.Models.Requests;
using Space.Imdb.Api.Models.Responses;
using Space.Imdb.Bll.Contracts.Interfaces.Service;
using Space.Imdb.Bll.Contracts.Models.Imdb.FilterData;
using Space.Imdb.Bll.Contracts.Models.Imdb.Filters;
using Space.Imdb.Infrastructure.Contracts.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Space.Imdb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImdbController : Controller
    {
        private readonly IImdService _imdbService;
        private readonly IMapper _mapper;

        public ImdbController(IImdService imdbService, IMapper mapper)
        {
            _mapper = mapper;
            _imdbService = imdbService;
        }


        [HttpGet]
        [Route("SearchMovieByTitle")]
        public async Task<Response<List<SearchMovieByTitleResponse>>> SearchMovieByTitle([FromQuery] SearchMovieByTitleRequest request)
        {
            var response = new Response<List<SearchMovieByTitleResponse>>();
            try
            {
                var result = await _imdbService.SearchMovieByTitle(_mapper.Map<MoviesByTitleFilter>(request));
                response.Data = _mapper.Map< List<MoviesByTitleFilterResult>, List<SearchMovieByTitleResponse>>(result.Results);
                response.Message = "Ok";
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
