using QuizShow.Context;
using QuizShow.Models;
using QuizShow.RepositoryPattern.Base;
using QuizShow.RepositoryPattern.Interfaces;

namespace QuizShow.RepositoryPattern.Concrate
{
    public class GameAnswersRepository : Repository<Answers>, IGameAnswersRepository
    {
        public GameAnswersRepository(MyDbContext db) : base(db)
        {
        }

        public bool AnswerInquiry(int id)
        {
            
            return table.Where(x => x.ID == id).Any(x => x.Truth == Enums.Truth.Doğru);
        }

        public List<Answers> GetAnswersWithQuestion(int QuestionID)
        {
            return table.Where(x => x.State != Enums.State.Deleted && x.QuestionID == QuestionID).ToList();

        }
    }
}
