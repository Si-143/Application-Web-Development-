public class Answer
    {
        int QuestionId;


        string answer;

        
    public int QuestionID
        {
            get { return QuestionId; }
            set { QuestionId = value; }
        }
    public string Answers
        {
            get { return answer; }
            set { answer = value; }
        }
         public Answer(int id, string ans)
        {
            QuestionId = id;
            answer = ans;
            
        }
    }
}
