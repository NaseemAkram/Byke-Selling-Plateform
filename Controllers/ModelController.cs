using BykeSellingOnlinePlatefrom.Appdata;
using BykeSellingOnlinePlatefrom.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BykeSellingOnlinePlatefrom.Controllers
{
    public class ModelController : Controller
    {
        private readonly VRoomDbContext _context;

        [BindProperty]
        public ModelViewModel ModelVM { get; set; }

        public ModelController(VRoomDbContext context)
        {
            _context = context;
            ModelVM = new ModelViewModel()
            {
                Makes = _context.Makes.ToList(),
                Model = new Models.Model()
            };

        }

        public IActionResult Index()
        {
            var models = _context.Models.Include(m => m.Make);
            return View(models);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(ModelVM);
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(ModelVM);
            }

            _context.Models.Add(ModelVM.Model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {
            ModelVM.Model = _context.Models.Include(m => m.Make).SingleOrDefault(m => m.Id == id);

            if (ModelVM.Model == null)
            {
                return NotFound();
            }

            return View(ModelVM);
        }


        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost()
        {
            if (!ModelState.IsValid)
            {
                return View(ModelVM);
            }

            _context.Update(ModelVM.Model);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var model = _context.Models.Find(id);
            if (model == null)
            {
                return NotFound();

            }

            _context.Remove(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
