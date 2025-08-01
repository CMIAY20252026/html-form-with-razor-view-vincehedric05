using Microsoft.AspNetCore.Mvc;

namespace StudentFormApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult StudentForm()
        {
            return View();
        }
    }
}
