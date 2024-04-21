using Microsoft.AspNetCore.Mvc;

namespace QuizShow.Areas.Management.Controllers
{
    [Area("Management")]
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
