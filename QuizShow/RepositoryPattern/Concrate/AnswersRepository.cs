using Microsoft.EntityFrameworkCore;
using QuizShow.Context;
using QuizShow.Dto;
using QuizShow.Models;
using QuizShow.RepositoryPattern.Base;
using QuizShow.RepositoryPattern.Interfaces;

namespace QuizShow.RepositoryPattern.Concrate
{
    public class AnswersRepository : Repository<Answers>, IAnswersRepository
    {
        public AnswersRepository(MyDbContext db) : base(db)
        {
        }

        public int AnswerCount(int QuestionID)
        {
            return table.Where(x => x.QuestionID == QuestionID && x.State != Enums.State.Deleted).Count();
        }

        public List<Answers> GetAnswersWithQuestion(int QuestionID)
        {
            return table.Where(x => x.State != Enums.State.Deleted  && x.QuestionID == QuestionID).ToList();

        }

        public int GetSymbolAnswers(int QuestionID, Enums.AnswerSymbol symbol)
        {
            return table.Where(x => x.QuestionID == QuestionID && x.State != Enums.State.Deleted && x.AnswerSymbol == symbol).Count();
        }
        public int GetSymbolAnswersUpdateMethod(int ID,int QuestionID, Enums.AnswerSymbol symbol)
        {
            return table.Where(x => x.QuestionID == QuestionID && x.ID !=ID && x.State != Enums.State.Deleted && x.AnswerSymbol == symbol).Count();
        }
        public int GetTrueAnswers(int QuestionID)
        {
            return table.Where(x => x.QuestionID == QuestionID && x.State != Enums.State.Deleted && x.Truth == Enums.Truth.Doğru).Count();
        }
        public int GetFalseAnswers(int QuestionID)
        {
            return table.Where(x => x.QuestionID == QuestionID && x.State != Enums.State.Deleted && x.Truth == Enums.Truth.Yanlış).Count();
        }

        public int GetTrueAnswersUpdateMethod(int ID,int QuestionID)
        {
            return table.Where(x => x.QuestionID == QuestionID && x.State != Enums.State.Deleted && x.Truth == Enums.Truth.Doğru && x.ID !=ID).Count();

        }
    }
}
