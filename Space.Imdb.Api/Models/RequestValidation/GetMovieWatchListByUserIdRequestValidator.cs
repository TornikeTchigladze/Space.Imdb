using FluentValidation;
using Space.Imdb.Api.Models.Requests;

namespace Space.Imdb.Api.Models.FluentValidation
{
    public class GetMovieWatchListByUserIdRequestValidator : AbstractValidator<GetMovieWatchListByUserIdRequest>
    {
        public GetMovieWatchListByUserIdRequestValidator()
        {
            RuleFor(r => r.UserId).NotNull().GreaterThan(0);
        }
    }
}
