using crud.Data;
using crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Controllers
{
    public class CarController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CarController(ApplicationDbContext db)
        {
            _db=db;
        }


        public IActionResult Index()
        {
            IEnumerable<Car> objList = _db.Cars;
            return View(objList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Car obj, IFormFile[] pic)
        { 
            if (ModelState.IsValid)
            {
/*           ADD IMAGES AS BYTE ARRAY*/
                _db.Cars.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null|| id==0)
            {
                return NotFound();
            }
            var obj=_db.Cars.Find(id);
            if (obj==null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Cars.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            _db.Cars.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _db.Cars.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Car obj)
        {
            if (ModelState.IsValid)
            {
                _db.Cars.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


    }

}

