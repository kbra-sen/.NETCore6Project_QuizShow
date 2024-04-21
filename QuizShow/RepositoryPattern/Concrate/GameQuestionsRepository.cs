using Microsoft.EntityFrameworkCore;
using QuizShow.Context;
using QuizShow.Dto;
using QuizShow.Models;
using QuizShow.RepositoryPattern.Base;
using QuizShow.RepositoryPattern.Interfaces;
using System.Drawing;

namespace QuizShow.RepositoryPattern.Concrate
{
    public class GameQuestionsRepository : Repository<Questions>, IGameQuestionsRepository
    {
        IRepository<Points> _repoPoints;
        public GameQuestionsRepository(MyDbContext db, IRepository<Points> repoPoints) : base(db)
        {

            _repoPoints = repoPoints;
        }

        
        public int getQuestionsCountWithPoint(int point)
        {
           return  table.Where(x => x.ActivePassive != Enums.ActiveOrPassive.Passive && x.State != Enums.State.Deleted && x.Point.Point == point).Count();
        }
        public QuestionsDto getNewQuestion(int PointID)
        {
            List<Points> p = _repoPoints.GetAvailable().OrderBy(x => x.Point).ToList();

            List<int> pid = new List<int>();
            foreach (Points item in p)
            {
                pid.Add(item.ID);
            }
            int newIndex = pid.IndexOf(PointID);
            int newPointID = p[newIndex+1].ID;
            
            List< QuestionsDto> qList=  table.Where(x=> x.PointID == newPointID).Select(x =>
           new QuestionsDto()
           {
               ID = x.ID,
               QuestDesc = x.QuestDesc,
               Point = x.Point.Point,
               PointID = x.PointID,
           }).ToList();
            return getQuestionsRandom(newPointID, qList);
        }
        public Points firstPointID()
        {
            return _repoPoints.GetAvailable().OrderBy(x => x.Point).First();
        }
        public Points getPointIDWithPointID(int pointID)
        {
            return _repoPoints.FindById(pointID);
        }
        public QuestionsDto getQuestionsRandom( int point,List<QuestionsDto> qList)
        {
            int startQuestionCount = getQuestionsCountWithPoint(point);
            Random rnd = new Random();
            int randomIndex = rnd.Next(startQuestionCount);
            return qList.ElementAt(randomIndex);
        }
      
        public List<QuestionsDto> getQuestionsWithPoint(int point)
        {
            return table.Where(x => x.ActivePassive == Enums.ActiveOrPassive.Active && x.State != Enums.State.Deleted && x.Point.Point == point).Include(x => x.Point).Select(x => 
            new QuestionsDto()
            {
                ID = x.ID,
                QuestDesc = x.QuestDesc,
                Point = x.Point.Point,
                PointID = x.PointID,
            }).ToList();
        }

        
    }
}
