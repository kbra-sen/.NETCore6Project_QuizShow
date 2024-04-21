using QuizShow.Enums;

namespace QuizShow.Dto
{
    public class QuestionsDto
    {
        public int ID { get; set; }
        public string QuestDesc { get; set; }
        public int Degree { get; set; }
        public ActiveOrPassive ActivePassive { get; set; }
        public int Order { get; set; }
        public int Point { get; set; }
        public int PointID { get; set; }
    }
}
