using Microsoft.EntityFrameworkCore;
using Space.Imdb.DB.Contracts.Entities;
using Space.Imdb.DB.Contracts.Interfaces.Repositories;

namespace Space.Imdb.DB.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
