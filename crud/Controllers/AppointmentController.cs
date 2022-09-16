using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            return Ok("your id = "+ id);
        }
    }
}
