using eTicket.Data;
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
        private readonly AppDbContext dbContext;

        public CinemasController(AppDbContext context)
        {
            dbContext = context;
        }
        public async  Task<IActionResult> Index()
        {
            var allCinemas = await dbContext.Cinemas.ToListAsync();
            return View();
        }
    }
}
