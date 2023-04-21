using BykeSellingOnlinePlatefrom.Appdata;
using BykeSellingOnlinePlatefrom.Models;
using Microsoft.AspNetCore.Mvc;

namespace BykeSellingOnlinePlatefrom.Controllers
{
    public class MakeController : Controller
    {
        private readonly VRoomDbContext _db;

        public MakeController(VRoomDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View(_db.Makes.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Make make)
        {
            if (ModelState.IsValid)
            {
                _db.Add(make);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(make);

        }

        public IActionResult Delete(int id)
        {
            var deletemake = _db.Makes.Find(id);
            if (deletemake == null)
            {
                return NotFound();

            }

            _db.Makes.Remove(deletemake);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var editmake = _db.Makes.Find(id);
            if (editmake == null)
            {
                return NotFound();
            }
            return View(editmake);
        }

        [HttpPost]

        public IActionResult Edit(Make make)
        {
            if (ModelState.IsValid)
            {
                _db.Makes.Update(make);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(make);
        }
    }
}
