using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizShow.Models.MetaDataTypes
{
    
    public class PointsMetaData
    {
        [Required(ErrorMessage = "Zorunlu Alan"), Column(TypeName = "int")]
        public int Point { get; set; }
    }
}
