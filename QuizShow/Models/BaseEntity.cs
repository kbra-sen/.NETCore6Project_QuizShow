using QuizShow.Enums;

namespace QuizShow.Models
{
    public abstract class BaseEntity //sadece miras verme işlemi oldugu için abstract, tüm modellerde olanları tanımlıyoruz base entityde
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            State = State.Inserted;
        }
        public int ID { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public State State { get; set; }
        
    }
}
