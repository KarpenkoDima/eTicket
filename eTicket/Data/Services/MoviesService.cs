using eTicket.Data.Base;
using eTicket.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eTicket.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _appDbContext;
        public MoviesService(AppDbContext appDbContext)
            :base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _appDbContext.Movies.Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies)
                .ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(m => m.Id == id);

            return  movieDetails;

        }
    }
}
