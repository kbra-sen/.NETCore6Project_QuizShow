using Microsoft.AspNetCore.Mvc;
using QuizShow.Dto;
using QuizShow.Models;
using QuizShow.RepositoryPattern.Interfaces;

namespace QuizShow.Areas.Management.Controllers
{
    [Area("Management")]
    public class QuestionsController : Controller
    {
        IQuestionsRepository _repoQuestion;
        IRepository<Points> _repoPoints;
        public QuestionsController(IQuestionsRepository repoQuestion, IRepository<Points> repoPoints )
        {
            _repoQuestion = repoQuestion;
            _repoPoints = repoPoints;
        }
        public IActionResult Add()
        {
            List<Points> p = _repoPoints.GetAvailable();
            return View((new Questions(),p));
        }
        [HttpPost]
        public IActionResult Add([Bind(Prefix ="Item1")] Questions q)
        {
             
          if(!ModelState.IsValid)
            {

                List<Points> p = _repoPoints.GetAvailable();
                return View((new Questions(), p));
            }
            _repoQuestion.Add(q);
            return RedirectToAction("List", "Questions", new { area = "Management" });
        }
        public IActionResult List()
        {

           List<QuestionsDto> q =  _repoQuestion.GetQuestions();
            return View(q);
        }
        public IActionResult Update(int id)
        {
            Questions q = _repoQuestion.FindById(id);
            List<Points> p = _repoPoints.GetAvailable();
            return View((q, p));
        }
        [HttpPost]
        public IActionResult Update([Bind(Prefix ="Item1")] Questions q)
        {
            if (!ModelState.IsValid)
            {
                 
                List<Points> p = _repoPoints.GetAvailable();
                return View((q, p));
            }
            _repoQuestion.Update(q);
            return RedirectToAction("List", "Questions", new { area = "Management" });
        }

        public IActionResult Delete(int id)
        {

             _repoQuestion.DeleteThenPassive(id);
            return RedirectToAction("List", "Questions", new { area = "Management" });
        }
        public  int UpdateStatus(int id, int value)
        {
           if(id != null)
            {
                _repoQuestion.UpdateStatus(id,value);
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
