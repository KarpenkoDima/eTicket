using eTicket.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult Index()
        {
            var data = dbContext.Actors.ToList();
            return View();
        }
    }
}
