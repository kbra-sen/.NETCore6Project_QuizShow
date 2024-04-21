using QuizShow.Dto;
using QuizShow.Models;

namespace QuizShow.RepositoryPattern.Interfaces
{
    public interface IGameQuestionsRepository : IRepository<Questions>
    {
        public int getQuestionsCountWithPoint(int point);
        public List<QuestionsDto> getQuestionsWithPoint(int point);
        public QuestionsDto getQuestionsRandom(int point, List<QuestionsDto> qList);
        public QuestionsDto getNewQuestion(int PointID);
        public Points firstPointID();
        public Points getPointIDWithPointID(int pointID);

    }
}
