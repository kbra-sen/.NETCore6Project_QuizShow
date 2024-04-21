using Microsoft.AspNetCore.Mvc;
using QuizShow.Models.MetaDataTypes;

namespace QuizShow.Models
{
    [ModelMetadataType(typeof(UserMetaData))]
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
