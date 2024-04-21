namespace QuizShow.Utils
{
    public class GameManager
    {

        private static GameManager? instance;
        private int questionNumber = 1;
      
        public static GameManager GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new GameManager();
                return instance;
            }
        }
       

        public int IncrementQuestionNumber ()
        {
            return ++questionNumber;
        }

        public int GetQuestionNumber()
        {
            return questionNumber;
        }

        public void ResetGameState()
        {
            questionNumber = 1;
        }
    }
}
