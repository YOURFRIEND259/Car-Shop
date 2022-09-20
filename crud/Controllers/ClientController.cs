using crud.Data;
using crud.Models;
using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ClientController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<Client> objList = _db.Clients;
            return View(objList);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Client obj)
        {
            if (ModelState.IsValid)
            {
                _db.Clients.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
