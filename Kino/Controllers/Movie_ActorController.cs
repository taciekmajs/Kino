using Kino.Data;
using Kino.Models.DB_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Kino.Controllers
{
    public class Movie_ActorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public Movie_ActorController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(int? movieId)
        {
            if (movieId == null || movieId == 0) return NotFound();
            var Movie_ActorList = _db.Movie_Actors.Where(x => x.MovieId == movieId);
            var Actors = _db.Actors;
            foreach (Actor a in Actors)
            {
                _db.Movie_Actors.Where(c => c.MovieId == a.Id).Load();
            }
            return View(Movie_ActorList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(IQueryable movie_ActorList)
        {



            return View();
        }

        public IActionResult Create(int? id)
        {
            ViewBag.MovieId = new SelectList(_db.Movies, "Id", "Title");
            ViewBag.ActorId = new SelectList(_db.Actors, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie_Actor movie_Actor)
        {
            if (ModelState.IsValid)
            {
                _db.Movie_Actors.Add(movie_Actor);
                _db.SaveChanges();
                return RedirectToAction("Index","Movie");
            }
            else
            {
                return View(movie_Actor);
            }
        }

    }
}
