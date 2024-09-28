using eTicket.Data.Base;
using eTicket.Models;

namespace eTicket.Data.Services
{
    public class MoviesService :EntityBaseRepository<Movie>, IMoviesService
    {
        public MoviesService(AppDbContext appDbContext)
            :base(appDbContext)
        {
            
        }
    }
}
