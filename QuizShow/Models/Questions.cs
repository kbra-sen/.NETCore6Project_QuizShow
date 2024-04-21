using Microsoft.AspNetCore.Mvc;
using QuizShow.Enums;
using QuizShow.Models.MetaDataTypes;
using System.ComponentModel.DataAnnotations;

namespace QuizShow.Models
{
    // [ModelMetadataType(typeof(QuestionsMetaData))]
    public class Questions : BaseEntity
    {
        public Questions()
        {
            ActivePassive = Enums.ActiveOrPassive.Active;
        }
        public string QuestDesc { get; set; }
        public int Degree { get; set; }
        public ActiveOrPassive ActivePassive { get; set; }
        public int Order { get; set; }
        public int PointID { get; set; }
         
        public virtual Points?  Point  { get; set; } // PointID için virtual tanımlamalıyız, points otomatik gelsin diye
        public virtual List<Answers>? Answer  { get; set; }

    }
}
