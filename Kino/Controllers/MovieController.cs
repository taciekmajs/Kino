using Kino.Data;
using Kino.Models.DB_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Kino.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MovieController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Movie> Movies = _db.Movies;
            var Genres = _db.Genres;
            var Directors = _db.Directors;

            foreach (Genre g in Genres)
            {
                _db.Movies.Where(c => c.GenreID == g.Id).Load();
            }

            foreach (Director d in Directors)
            {
                _db.Movies.Where(c => c.DirectorID == d.Id).Load();
            }
            return View(Movies);
        }

        //GET
        public IActionResult Create()
        {
            ViewBag.GenreId = new SelectList(_db.Genres, "Id", "Name");
            ViewBag.DirectorId = new SelectList(_db.Directors, "Id", "Name");
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _db.Movies.Add(movie);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(movie);
            }
        }

        public IActionResult Remove(int? id)
        {
            if (id == null || id == 0) return NotFound();
            var movie = _db.Movies.FirstOrDefault(x => x.Id == id);

            if (movie != null)
            {
                _db.Movies.Remove(movie);
                _db.SaveChanges();
            }
            else return NotFound();

            return RedirectToAction("Index");
        }


    }
}
