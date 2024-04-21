using System.ComponentModel.DataAnnotations;

namespace QuizShow.Models.MetaDataTypes
{
    public class UserMetaData
    {
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Password { get; set; }
    }
}
