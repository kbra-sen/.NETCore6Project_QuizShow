using QuizShow.Models;

namespace QuizShow.RepositoryPattern.Interfaces
{
    public interface IGameAnswersRepository : IRepository<Answers>
    {
        public List<Answers> GetAnswersWithQuestion(int QuestionID);
        public bool AnswerInquiry(int id);
        
    }
}
