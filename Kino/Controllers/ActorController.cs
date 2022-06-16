using Kino.Data;
using Kino.Models.DB_Models;
using Microsoft.AspNetCore.Mvc;

namespace Kino.Controllers
{
    public class ActorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ActorController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Actor> actors = _db.Actors;
            return View(actors);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Actor actor)
        {
            if (ModelState.IsValid)
            {
                _db.Actors.Add(actor);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(actor);
            }
        }


        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();
            var genre = _db.Genres.FirstOrDefault(x => x.Id == id);

            if (genre != null) return View(genre);
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
