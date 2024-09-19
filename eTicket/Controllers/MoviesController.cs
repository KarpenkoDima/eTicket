using eTicket.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext dbContext;

        public MoviesController(AppDbContext context)
        {
            dbContext = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await dbContext.Movies.ToListAsync();
            return View();
        }
    }
}
