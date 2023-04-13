using crud.Data;
using crud.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace crud.Controllers
{
    public class CarController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CarController(ApplicationDbContext db)
        {
            _db = db;
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
        public async Task<IActionResult> Create([Bind("Id,Mark,Model,Color,Price")] Car obj, IFormFile Picture)
        {
            if (ModelState.IsValid)
            {
                if (Picture != null && Picture.Length > 0)
                {
                    byte[] pictureBytes;
                    using (var ms = new MemoryStream())
                    {
                        await Picture.CopyToAsync(ms);
                        pictureBytes = ms.ToArray();
                    }
                    obj.Picture = pictureBytes;
                }

                _db.Cars.Add(obj);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }
        public async Task<ActionResult> RenderImage(int id)
        {
            Car item = await _db.Cars.FindAsync(id);

            byte[] photoBack = item.Picture;

            return File(photoBack, "image/png");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
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
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Cars.Find(id);
            if (obj == null)
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

