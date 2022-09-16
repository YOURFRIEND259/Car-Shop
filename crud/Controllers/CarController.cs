using crud.Data;
using crud.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
