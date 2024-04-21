using Microsoft.AspNetCore.Mvc;
using QuizShow.Models;
using QuizShow.RepositoryPattern.Interfaces;

namespace QuizShow.Areas.Management.Controllers
{
    [Area("Management")]
    public class PointsController : Controller
    {
        IRepository<Points> _repoPoints;
        public PointsController(IRepository<Points> repoPoints)
        {

            _repoPoints = repoPoints;
          
        }
        public IActionResult List()
        {
           List<Points> p = _repoPoints.GetAvailable();
            return View(p);
        }
        public IActionResult Add()
        {
           
            return View( );
        }
        [HttpPost]
        public IActionResult Add(Points p)
        {
            _repoPoints.Add(p);
            return RedirectToAction("List", "Points", new { area = "Management" });
        }
        public IActionResult Update(int id)
        {
          Points p=  _repoPoints.FindById(id);

            return View(p);
        }
        [HttpPost]
        public IActionResult Update(Points p)
        {
            _repoPoints.Update(p); 
       
            return RedirectToAction("List", "Points", new { area = "Management" });
        }
        public IActionResult Delete(int id)
        {
            
            _repoPoints.Delete(id);
            return RedirectToAction("List", "Points", new { area = "Management" });

        }
    }
}
