using eTicket.Data;
using eTicket.Data.Services;
using eTicket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService cinemasService;

        public CinemasController(ICinemasService service)
        {
            cinemasService = service;
        }
        public async  Task<IActionResult> Index()
        {
            var allCinemas = await cinemasService.GetAllAsync();
            return View(allCinemas);
        }

        // GET: cinemas/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo, Name, Description")] Cinema cinema)
        {
            if (false == ModelState.IsValid)
            {
                return View(cinema);
            }

            await cinemasService.AddAsync(cinema);
            return RedirectToAction("Index");
        }

        // GET: cinemas/details/id
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await cinemasService.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");

            return View(cinemaDetails);
        }
    }
}
