using FluentValidation;
using Space.Imdb.Api.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Space.Imdb.Api.Models.FluentValidation
{
    public class SaveMovieInWatchListRequestValidator : AbstractValidator<SaveMovieInWatchListRequest>
    {
        public SaveMovieInWatchListRequestValidator() 
        {
            RuleFor(r => r.MovieId).NotEmpty().Length(0, 100);
            RuleFor(r => r.UserId).NotNull().GreaterThan(0);
        }
    }
}
