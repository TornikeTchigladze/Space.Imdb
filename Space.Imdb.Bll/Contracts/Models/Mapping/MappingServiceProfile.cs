using AutoMapper;
using Space.Imdb.Bll.Contracts.Models.Imdb.FilterData.MovieService;
using Space.Imdb.Bll.Contracts.Models.Imdb.Filters;
using Space.Imdb.Bll.Contracts.Models.WatchList.Filter;
using Space.Imdb.Bll.Contracts.Models.WatchList.FilterData;
using Space.Imdb.DB.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Space.Imdb.Bll.Contracts.Models.Mapping
{
    public class MappingServiceProfile : Profile
    {
        public MappingServiceProfile()
        {
            CreateMap<MovieByIdFilterData, Movie>().ForMember(dest => dest.Id, act => act.Ignore())
                                                   .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.Id));
            CreateMap<PosterDataItem, MoviePoster>().ForMember(dest => dest.Id, act => act.Ignore())
                                                    .ForMember(dest=>dest.Poster,opt=>opt.MapFrom(src=>src.Id));

            CreateMap<Watchlist, WatchListByUserIdFilterData>();

            CreateMap<WikipediaDataPlot, MovieWikiShort>();
            CreateMap<WatchListSaveFilter, MovieInfoByIdFilter>();
            CreateMap<WatchListSaveFilter, MovieWikiByIdFilter>();
            CreateMap<WatchListSaveFilter, MoviePosterByIdFilter>();
        }
    }
}
