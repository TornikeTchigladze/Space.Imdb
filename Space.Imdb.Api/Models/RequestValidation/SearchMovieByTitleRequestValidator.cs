using FluentValidation;
using Space.Imdb.Api.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Space.Imdb.Api.Models.FluentValidation
{
    public class SearchMovieByTitleRequestValidator :  AbstractValidator<SearchMovieByTitleRequest>
    {
        public SearchMovieByTitleRequestValidator()
        {
            RuleFor(r => r.Title).NotEmpty().Length(0, 100);
        }
    }
}
