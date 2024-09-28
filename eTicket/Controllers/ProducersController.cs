using eTicket.Data;
using eTicket.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eTicket.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService producersService;

        public ProducersController(IProducersService service)
        {
            producersService = service;
        }
        public async Task<IActionResult> Index()
        {
            var allProducers = await producersService.GetAllAsync();
            return View(allProducers);
        }

        // GET: prodeucers/details/1
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await producersService.GetByIdAsync(id);
            if (producerDetails == null) 
            {
                return View("NotFound");
            }
            return View(producerDetails);
        }
    }
}
