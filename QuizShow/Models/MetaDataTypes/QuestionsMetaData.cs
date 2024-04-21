using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizShow.Models.MetaDataTypes
{
    public class QuestionsMetaData
    {

        [Required(ErrorMessage ="Zorunlu Alan"), Column(TypeName ="nvarchar(350)")]
        public string QuestDesc { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public int Degree { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        
        public int PointID { get; set; }


        [Required(ErrorMessage = "Zorunlu Alan")]
        public int Order { get; set; }
    }
}
