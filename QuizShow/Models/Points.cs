using Microsoft.AspNetCore.Mvc;
using QuizShow.Models.MetaDataTypes;

namespace QuizShow.Models
{
    [ModelMetadataType(typeof(PointsMetaData))]
    public class Points : BaseEntity
    {
        public int Point { get; set; }
        public virtual List<Questions> Question  { get; set; }
    }
}
