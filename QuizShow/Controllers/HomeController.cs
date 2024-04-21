using Microsoft.AspNetCore.Mvc;
using QuizShow.Enums;
using System.Drawing;

namespace QuizShow.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int Point ,int  State )
        {
            if(Point ==null || State== null )
            {
                Point = 0;
                State = 0;
            }
            return View((Point, State));
        }
    }
}
