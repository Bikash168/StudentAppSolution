using Microsoft.AspNetCore.Mvc;

namespace StudentApp.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
