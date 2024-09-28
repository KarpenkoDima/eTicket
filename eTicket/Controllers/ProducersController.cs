using eTicket.Data;
using eTicket.Data.Services;
using eTicket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
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

        // GET: producers/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePicture, FullName, Bio")]Producer producer)
        {
            if (false == ModelState.IsValid) return View(producer);

            await producersService.AddAsync(producer);
            return RedirectToAction("Index");
        }

        // GET: producers/edit
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await producersService.GetByIdAsync(id);
            if (producerDetails == null)
            {
                return View("NotFound");
            }
            return View(producerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, ProfilePicture, FullName, Bio")] Producer producer)
        {
            if (false == ModelState.IsValid) return View(producer);

            if (producer.Id == id)
            {
                await producersService.UpdateAsync(id, producer);
                return RedirectToAction("Index");
            }
            return View(producer);
        }
    }
}
