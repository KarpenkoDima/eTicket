using eTicket.Data;
using eTicket.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eTicket.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService actorsService;

        public ActorsController(IActorsService service)
        {
            actorsService = service;
        }
        public async Task<IActionResult> Index()
        {
            var allActors = await actorsService.GetAll();
            return View(allActors);
        }

        // Get: Actors/Create
        public IActionResult Create()
        {

            return View();
        }
    }
}
