using Microsoft.AspNetCore.Mvc;
using QuizShow.Dto;
using QuizShow.Models;
using QuizShow.RepositoryPattern.Interfaces;
using QuizShow.Utils;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Runtime.Intrinsics.Arm;

namespace QuizShow.Controllers
{
    public class Game : Controller
    {
        GameManager instance = GameManager.GetInstance;
        IGameQuestionsRepository _repoGameQuestions;
        IGameAnswersRepository _repoGameAnswers;
     
        public Game(IGameQuestionsRepository repoGameQuestions, IGameAnswersRepository repoGameAnswers)
        {
            _repoGameQuestions = repoGameQuestions;
            _repoGameAnswers = repoGameAnswers;
            
        }

        public List<Answers> GetAnswers(int QuestionID)
        {
            return _repoGameAnswers.GetAnswersWithQuestion(QuestionID);
        }

        public IActionResult GameStart()
        { 
            Points p = _repoGameQuestions.firstPointID();
            List<QuestionsDto> qList = _repoGameQuestions.getQuestionsWithPoint(p.Point);
            QuestionsDto q = _repoGameQuestions.getQuestionsRandom(p.Point, qList);
            return View((GetAnswers(q.ID), q, instance.GetQuestionNumber()));
            
        }
        [HttpPost]
        public IActionResult GameStart(int PointID, int answerID)
        {
         
            if (_repoGameAnswers.AnswerInquiry(answerID))
            {
                QuestionsDto q = _repoGameQuestions.getNewQuestion(PointID);
                 return View((GetAnswers(q.ID), q, instance.IncrementQuestionNumber()));
            }
            else
            {
                Points p = _repoGameQuestions.getPointIDWithPointID(PointID);
                instance.ResetGameState();
                return RedirectToAction("Index", "Home", new
                {
                    Point = p.Point,
                    State = 1
                }) ;
               
            }

        }
    }
}
