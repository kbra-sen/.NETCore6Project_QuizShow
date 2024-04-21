using QuizShow.Dto;
using QuizShow.Models;

namespace QuizShow.RepositoryPattern.Interfaces
{
    public interface IQuestionsRepository : IRepository<Questions>
    {
        public List<QuestionsDto> GetQuestions();
        public List<QuestionsDto> GetActiveQuestions();
        public void DeleteThenPassive(int id);
        public List<QuestionsDto>  GetRandomQuestions(int order);
        public void UpdateStatus(int id, int value);
        public void UpdateQuestion(Questions item);
        public Questions GetQuestionByID(int ID);
    }
}
