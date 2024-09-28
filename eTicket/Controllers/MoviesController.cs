using eTicket.Data;
using eTicket.Data.Services;
using eTicket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService moviesService;

        public MoviesController(IMoviesService service)
        {
            moviesService = service;
        }
        public async Task<IActionResult> Index()
        {
            var allMovies = await moviesService.GetAllAsync(m => m.Cinema);
            return View(allMovies);
        }

        // GET: movies/details/id
        public async Task<IActionResult> Details(int id)
        { 
            var movieDetails = await moviesService.GetMovieByIdAsync(id);
            return View(movieDetails);
        }
    }
}
