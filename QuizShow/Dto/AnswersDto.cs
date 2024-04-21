using QuizShow.Enums;

namespace QuizShow.Dto
{
    public class AnswersDto
    {
        public int ID { get; set; }
        public string AnswerDesc { get; set; }
        public Truth Truth { get; set; }
        public AnswerSymbol AnswerSymbol { get; set; }
        public string QuestionDesc { get; set; }
        public int QuestionID { get; set; }
         public State State { get; set; }
    }
}
