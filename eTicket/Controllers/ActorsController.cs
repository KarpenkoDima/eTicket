using eTicket.Data;
using eTicket.Data.Services;
using eTicket.Models;
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

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePicture, Bio")]Actor actor)
        {
            if (false == ModelState.IsValid)
            {
                return View(actor);
            }
            actorsService.Add(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await actorsService.GetById(id);

            if (actorDetails == null)
            {
                return View("Not Found");
            }
            return View(actorDetails);
        }


        // Get: Actors/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await actorsService.GetById(id);

            if (actorDetails == null)
            {
                return View("Not Found");
            }
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, FullName, ProfilePicture, Bio")] Actor actor)
        {
            if (false == ModelState.IsValid)
            {
                return View(actor);
            }
            await actorsService.Update(id, actor);
            return RedirectToAction(nameof(Index));
        }

        // Get: Actors/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await actorsService.GetById(id);

            if (actorDetails == null)
            {
                return View("Not Found");
            }
            return View(actorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await actorsService.GetById(id);

            if (actorDetails == null)
            {
                return View("Not Found");
            }
            await actorsService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}