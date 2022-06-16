using Kino.Data;
using Kino.Models.DB_Models;
using Microsoft.AspNetCore.Mvc;

namespace Kino.Controllers
{
    public class GenreController : Controller
    {
        private readonly ApplicationDbContext _db;

        public GenreController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Genre> GenresList = _db.Genres;
            return View(GenresList);
        }


        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _db.Genres.Add(genre);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(genre);
            }
        }


        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();
            var genre = _db.Genres.FirstOrDefault(x => x.Id == id);

            if (genre!=null) return View(genre);
            return NotFound();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _db.Genres.Update(genre);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(genre);
            }
        }

        //GET
        public IActionResult Remove(int? id)
        {
            if (id == null || id == 0) return NotFound();
            var genre = _db.Genres.FirstOrDefault(x => x.Id == id);

            if (genre != null)
            {
                _db.Genres.Remove(genre);
                _db.SaveChanges();
            }
            else return NotFound();

            return RedirectToAction("Index");
        }
    }
}
