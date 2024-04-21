using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using QuizShow.Dto;
using QuizShow.Models;
using QuizShow.RepositoryPattern.Interfaces;

namespace QuizShow.Areas.Management.Controllers
{
    [Area("Management")]
   
    public class AnswersController : Controller
    {
        IAnswersRepository _repoAnswers;
        IQuestionsRepository _repoQuestion;
        public AnswersController(IAnswersRepository repoAnswers, IQuestionsRepository repoQuestions)
        {
            _repoAnswers = repoAnswers;
            _repoQuestion= repoQuestions;
        }
        //cevabı eksik olan sorular pasif olsun. PAsif sorular adı altında liste yap
        //cevabı silince eksikleri kırmızı göstermeyi unutma
        //soruyu silince cevaplarıda sildirmeyi unutma
     /*   public IActionResult ValidationFunc(int type,int AnswerID,int QuestionID,Enums.AnswerSymbol symbol)
        {
            string Quest = "";
            Questions q = _repoQuestion.GetQuestionByID(answer.QuestionID);
            if (q != null)
            {
                Quest = "'" + q.QuestDesc + "' sorusunun";
            }
            else
            {
                Quest = "Bu Sorunun";
            }
            if (answer.Truth == Enums.Truth.Doğru && getAnswerTruth > 0)
            {
                TempData["Error"] = Quest + " doğru cevabı daha önce girilmiş!";
                return View((new Answers(), answer.QuestionID));
            }
            if (type==1)
            {
                int count = _repoAnswers.AnswerCount(AnswerID);
                if (count == 4)
                {
                    TempData["Error"] = "Bir soru için 4 den fazla cevap girilemez. Soruya ait cevapları aşağıdaki menüden günceleyebilir yada silebilirsiniz";
                    
                }
            }

            return   RedirectToAction("List", "Answers", new { area = "Management" });
        }
     */
        public IActionResult List()
        {
            List<Answers> ans = null;
            List<QuestionsDto> questions = _repoQuestion.GetQuestions();
            return View((new Answers(), ans, questions));
        }
        [HttpPost]
        public IActionResult List([Bind(Prefix = "Item1")] Answers answer)
        {
            string Quest = "";
            int ansCount = _repoAnswers.AnswerCount(answer.QuestionID);
            Questions q = _repoQuestion.GetQuestionByID(answer.QuestionID);
            if(q !=null)
            {
                  Quest = "'" + q.QuestDesc + "' sorusunun";
            }
            else
            {
                  Quest = "Bu Sorunun";
            }
          /*  if (ansCount < 4)
            {
                TempData["Error"] = Quest + " 4 den az cevabı var. Önce ekleme yapınız. Ekleme sayfasına yönlendirildiniz.";
                return RedirectToAction("List", "Questions", new { area = "Management" });
            }*/
            List<Answers> ans = _repoAnswers.GetAnswersWithQuestion(answer.QuestionID);
            List<QuestionsDto> questions = _repoQuestion.GetQuestions();
            return View((new Answers(), ans, questions));
        }
     
        public IActionResult Add(int id)
        {
            int count = _repoAnswers.AnswerCount(id);
            if (count == 4)
            {
                TempData["Error"] = "Bir soru için 4 den fazla cevap girilemez. Soruya ait cevapları aşağıdaki menüden günceleyebilir yada silebilirsiniz";
                return RedirectToAction("List", "Answers", new { area = "Management" });
            }
            else
            {
                return View((new Answers(), id));
            }
            
        }
        [HttpPost]
        public IActionResult Add([Bind(Prefix ="Item1")] Answers answer)
        {
            int getAnswerTruth = _repoAnswers.GetTrueAnswers(answer.QuestionID);
            int getAnswerSymbolCount = _repoAnswers.GetSymbolAnswers(answer.QuestionID, answer.AnswerSymbol);
            string Quest = "";
            int getAnswerTruthFalse = _repoAnswers.GetFalseAnswers(answer.QuestionID);

            Questions q = _repoQuestion.GetQuestionByID(answer.QuestionID);
            if (q != null)
            {
                Quest = "'" + q.QuestDesc + "' sorusunun";
            }
            else
            {
                Quest = "Bu Sorunun";
            }
            if (answer.Truth == Enums.Truth.Doğru && getAnswerTruth > 0)
            {
                TempData["Error"] = Quest + " doğru cevabı daha önce girilmiş!";
                return View((new Answers(), answer.QuestionID));
            }
            if (getAnswerSymbolCount > 0)
            {
                TempData["Error"] = Quest + " bu şıkkı daha önce girilmiş!";
                return View((new Answers(), answer.QuestionID));
            }
            if (answer.Truth == Enums.Truth.Yanlış && getAnswerTruthFalse >= 3)
            {
                TempData["Error"] = Quest + " 3 yanlış cevabı daha önce girilmiş!";
                return View((new Answers(), answer.QuestionID));
            }
            _repoAnswers.Add(answer);
            return RedirectToAction("List","Answers",new {area="Management"}); 
        }
        public IActionResult Delete(int id)
        {
            _repoAnswers.Delete(id);
            return RedirectToAction("List", "Answers", new { area = "Management" });
        }

        public IActionResult Update(int id,int questID)
        {
            Answers ans = _repoAnswers.FindById(id);
                return View((ans, questID));
           

        }
        [HttpPost]
        public IActionResult Update([Bind(Prefix ="Item1")] Answers answer)
        {
           if(!ModelState.IsValid)
            {
                Answers ans = _repoAnswers.FindById(answer.ID);
                return View((ans, answer.QuestionID));

            }
            string Quest = "";
            Questions q = _repoQuestion.GetQuestionByID(answer.QuestionID);
            if (q != null)
            {
                Quest = "'" + q.QuestDesc + "' sorusunun";
            }
            else
            {
                Quest = "Bu Sorunun";
            }
            int getAnswerTruthFalse = _repoAnswers.GetFalseAnswers(answer.QuestionID);
            int getAnswerTruthTrue = _repoAnswers.GetTrueAnswersUpdateMethod(answer.ID,answer.QuestionID);
            int getAnswerSymbolCount = _repoAnswers.GetSymbolAnswersUpdateMethod(answer.ID,answer.QuestionID, answer.AnswerSymbol);
            if (answer.Truth == Enums.Truth.Doğru && getAnswerTruthTrue > 0)
            {
                TempData["Error"] = Quest+ " doğru cevabı daha önce girilmiş!";
                Answers ans = _repoAnswers.FindById(answer.ID);
                return View((ans, answer.QuestionID));
            }
            if (answer.Truth == Enums.Truth.Yanlış && getAnswerTruthFalse > 3)
            {
                TempData["Error"] = Quest+ " 3 yanlış cevabı daha önce girilmiş!";
                Answers ans = _repoAnswers.FindById(answer.ID);
                return View((ans, answer.QuestionID));
            }
            if (getAnswerSymbolCount > 0)
            {
                TempData["Error"] = Quest+ " bu şıkkı daha önce girilmiş!";
                Answers ans = _repoAnswers.FindById(answer.ID);
                return View((ans, answer.QuestionID));
            }
            _repoAnswers.Update(answer);
            return RedirectToAction("List", "Answers", new { area = "Management" });


        }
    }
}
