using FluentValidation;
using Space.Imdb.Api.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Space.Imdb.Api.Models.FluentValidation
{
    public class MarkedMovieAsWatchedRequestValidator : AbstractValidator<MarkedMovieAsWatchedRequest>
    {
        public MarkedMovieAsWatchedRequestValidator()
        {
            RuleFor(r => r.WatchListId).NotNull().GreaterThan(0);
        }
    }
}
