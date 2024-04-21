
using Microsoft.EntityFrameworkCore;
using QuizShow.Context;
using QuizShow.Dto;
using QuizShow.Models;
using QuizShow.RepositoryPattern.Base;
using QuizShow.RepositoryPattern.Interfaces;

namespace QuizShow.RepositoryPattern.Concrate
{
    public class QuestionRepository :   Repository<Questions> ,IQuestionsRepository 
    {
        public QuestionRepository(MyDbContext db) : base(db)
        {
        }

        public void DeleteThenPassive(int id)
        {
            Questions q = FindById(id);
            q.ActivePassive = Enums.ActiveOrPassive.Passive;
            q.State = Enums.State.Deleted;
            q.ModifiedDate = DateTime.Now;
            table.Update(q);
            Save();


        }
        public void UpdateStatus(int id,int value)
        {
            Questions item = FindById(id);
           item.ActivePassive =  (value == 1) ? Enums.ActiveOrPassive.Active : Enums.ActiveOrPassive.Passive;
            item.ModifiedDate = DateTime.Now;
            item.State = Enums.State.Updated;
            table.Update(item);
            Save();
        }
        public List<QuestionsDto> GetActiveQuestions()
        {
            return table.Where(x => x.State != Enums.State.Deleted && x.ActivePassive == Enums.ActiveOrPassive.Active).Include(x => x.Point).Select(x => new QuestionsDto
            {
                ID = x.ID,
                QuestDesc = x.QuestDesc,
                Degree = x.Degree,
                ActivePassive = x.ActivePassive,
                Point = x.Point.Point,
                Order = x.Order

            }).ToList();
        }

        public List<QuestionsDto> GetQuestions()
        {
            return table.Where(x => x.State != Enums.State.Deleted).Include(x => x.Point).Select(x => new QuestionsDto
            {
                ID = x.ID,
                QuestDesc = x.QuestDesc,
                Degree = x.Degree,
                ActivePassive = x.ActivePassive,
                Point = x.Point.Point,
                Order = x.Order

            }).OrderByDescending(x=> x.ID).ToList();
        }

        public List<QuestionsDto> GetRandomQuestions(int order)
        {
            return table.Where(x => x.State != Enums.State.Deleted && x.ActivePassive == Enums.ActiveOrPassive.Active && x.Order == order).Include(x => x.Point).OrderBy(r => Guid.NewGuid()).Select(x => new QuestionsDto
            {
                ID = x.ID,
                QuestDesc = x.QuestDesc,
                Degree = x.Degree,
                ActivePassive = x.ActivePassive,
                Point = x.Point.Point,
                Order = x.Order

            }).Take(1).ToList();
        }

        public void UpdateQuestion(Questions item)
        {
            Questions q = FindById(item.ID);
            if(q !=  null)
            {
                        item.ModifiedDate = DateTime.Now;
                        item.State = Enums.State.Updated;
                        table.Update(item);
                        Save();
            }
            else
            {
                Console.WriteLine("böyle id yok");
            }
           
        }

        public Questions GetQuestionByID(int ID)
        {
            return table.Where(x => x.ID == ID).SingleOrDefault();
        }
    }
}
