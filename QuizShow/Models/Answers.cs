using Microsoft.AspNetCore.Mvc;
using QuizShow.Enums;
using QuizShow.Models.MetaDataTypes;

namespace QuizShow.Models
{


    [ModelMetadataType(typeof(AnswersMetaData))]
    public class Answers : BaseEntity
    {
        public string AnswerDesc { get; set; }
        public Truth Truth { get; set; }
        public AnswerSymbol AnswerSymbol { get; set; }
        public int QuestionID { get; set; }

        public virtual Questions? Question { get; set; }

    }
}
