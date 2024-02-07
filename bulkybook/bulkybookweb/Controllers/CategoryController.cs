using bulkybookweb.Data;
using bulkybookweb.Models;
using Microsoft.AspNetCore.Mvc;

namespace bulkybookweb.Controllers
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
            IEnumerable<Category> CategoryObject = _db.Categories.ToList();   
            return View(CategoryObject);
        }
        
        //Get
        public IActionResult Create()
        {
            
            return View();
        }

        //Post

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The display order cannot exactly match the name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();  
            }
            var categoryobj = _db.Categories.Find(id);

            if (categoryobj == null)
            {
                return NotFound();
            }
            return View(categoryobj);
        }


        //Post

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The display order cannot exactly match the name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }



        //Get
        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Categories.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //Post

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(Category obj)
        {
            
            
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            
            
        }









    }
}
