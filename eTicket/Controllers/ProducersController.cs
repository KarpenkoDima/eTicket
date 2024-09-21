using eTicket.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eTicket.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext dbContext;

        public ProducersController(AppDbContext context)
        {
            dbContext = context;
        }
        public async Task<IActionResult> Index()
        {
            var allProducers = await dbContext.Producers.ToListAsync();
            return View(allProducers);
        }
    }
}
