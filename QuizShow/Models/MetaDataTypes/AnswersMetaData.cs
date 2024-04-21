using QuizShow.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizShow.Models.MetaDataTypes
{
    public class AnswersMetaData
    {
        [Required(ErrorMessage ="Zorunlu Alan")]
        [ Column(TypeName = "nvarchar(200)")]
        public string AnswerDesc { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public Truth Truth { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan"), Column(TypeName = "nvarchar(10)")]
        public string AnswerSymbol { get; set; }
         
    }
}
