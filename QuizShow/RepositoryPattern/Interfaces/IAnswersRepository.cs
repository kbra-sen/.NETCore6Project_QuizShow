using QuizShow.Models;

namespace QuizShow.RepositoryPattern.Interfaces
{
    public interface IAnswersRepository : IRepository<Answers>
    {
        public int AnswerCount(int QuestionID);
        public List<Answers> GetAnswersWithQuestion(int QuestionID);
        public int GetSymbolAnswers(int QuestionID, Enums.AnswerSymbol symbol);
        public int GetSymbolAnswersUpdateMethod(int ID, int QuestionID, Enums.AnswerSymbol symbol);
        public int GetTrueAnswers(int QuestionID);
        public int GetFalseAnswers(int QuestionID);
        public int GetTrueAnswersUpdateMethod(int ID, int QuestionID);
    }
}
