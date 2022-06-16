using Kino.Data;
using Microsoft.AspNetCore.Mvc;
using Kino.Models.DB_Models;

namespace Kino.Controllers
{
    public class DirectorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DirectorController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Director> DirectorsList = _db.Directors;
            return View(DirectorsList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Director director)
        {
            if (ModelState.IsValid)
            {
                _db.Directors.Add(director);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(director);
            }
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();
            var director = _db.Directors.FirstOrDefault(x => x.Id == id);

            if (director != null) return View(director);
            return NotFound();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Director director)
        {
            if (ModelState.IsValid)
            {
                _db.Directors.Update(director);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(director);
            }
        }

        //GET
        public IActionResult Remove(int? id)
        {
            if (id == null || id == 0) return NotFound();
            var director = _db.Directors.FirstOrDefault(x => x.Id == id);

            if (director != null)
            {
                _db.Directors.Remove(director);
                _db.SaveChanges();
            }
            else return NotFound();

            return RedirectToAction("Index");
        }


    }
}
