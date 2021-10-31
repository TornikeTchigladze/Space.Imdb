using AutoMapper;
using Space.Imdb.Api.Models.Requests;
using Space.Imdb.Api.Models.Responses;
using Space.Imdb.Bll.Contracts.Models.Imdb.FilterData;
using Space.Imdb.Bll.Contracts.Models.Imdb.Filters;
using Space.Imdb.Bll.Contracts.Models.WatchList.Filter;
using Space.Imdb.Bll.Contracts.Models.WatchList.FilterData;

namespace Space.Imdb.Api.Models.Mapping
{
    public class MappingApiProfile : Profile
    {
        public MappingApiProfile()
        {
            CreateMap<SearchMovieByTitleRequest, MoviesByTitleFilter>();
            CreateMap<MoviesByTitleFilterResult, SearchMovieByTitleResponse>();
            CreateMap<SaveMovieInWatchListRequest, MovieInfoByIdFilter>();
            CreateMap<SaveMovieInWatchListRequest, WatchListSaveFilter>();
            CreateMap<GetMovieWatchListByUserIdRequest, WatchListByUserIdFilter>(); 
            CreateMap<WatchListByUserIdFilterData, GetMovieWatchListByUserIdResponse>().ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie.Title))
                                                                                       .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Users.UserName));
            CreateMap<MarkedMovieAsWatchedRequest, WatchListMarkedWatchedFIlter>();
        }
    }
}
