using BlurryBooks.Data;
using BlurryBooks.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlurryBooks.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCat = _db.Categories.ToList();
            return View(objCat);
        }
        //GET REQ
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.OrderID.ToString())
            {
                ModelState.AddModelError("CustomError","Display Id and Name cannot be same!");
            }
            if (ModelState.IsValid)
            {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

            }
            return View();
        }
        //GET
        public IActionResult Edit(int? id)
        {
           if(id==null || id == 0)
            {
                return NotFound();
            }
            var categories = _db.Categories.Find(id);
            if (categories == null)
            {
                return NotFound();
            }
            return View(categories);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.OrderID.ToString())
            {
                ModelState.AddModelError("CustomError", "Display Id and Name cannot be same!");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
