using Microsoft.AspNetCore.Mvc;
using mvcProject.Data;
using mvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcProject.Controllers
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
            IEnumerable<Category> objList = _db.Category;   // This 1 line grabs all the categories
            return View(objList);
        }

        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)   // Server side validation
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");   // Redirects to action Index
            }
            return View(obj);   // if it is not valid, return the view, and I am passing in the object so I can use it to display the error message
        }

        // GET - EDIT
        public IActionResult Edit(int? id)   // The question mark after int means that this could be a nullable field
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }


            return View(obj);   // if the object is found = return it the view to be displayed
        }

        // POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)   // Server side validation
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");   // Redirects to action Index
            }
            return View(obj);   // if it is not valid, return the view, and I am passing in the object so I can use it to display the error message
        }

        // GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }


            return View(obj);
        }

        // POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)   // id changed from obj ... ALSO ... Delete needs to be changed to something else because these functions can't be overloaded ... they have the same int? value
        {
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Category.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
