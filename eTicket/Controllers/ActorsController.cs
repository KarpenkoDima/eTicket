using eTicket.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eTicket.Controllers
{
    public class ActorsController : Controller
    {
        private readonly AppDbContext dbContext;

        public ActorsController(AppDbContext context)
        {
            dbContext = context;
        }
        public async Task<IActionResult> Index()
        {
            var allActors = await dbContext.Actors.ToListAsync();
            return View();
        }
    }
}
