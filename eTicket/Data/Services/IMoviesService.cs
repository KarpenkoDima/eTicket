using eTicket.Data.Base;
using eTicket.Models;
using System.Threading.Tasks;

namespace eTicket.Data.Services
{
    public interface IMoviesService :IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
    }
}
