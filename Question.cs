public class Questions
    { 
       
        int questionID;
        string questions;
  
        
        public int qID
        {
            get { return questionID;}
            set { questionID = value;}
        }
        public string q
        {
            get { return questions; }
            set { questions = value; }

        }

        public Questions(int QId,string Q)
        {
            questionID = QId;
            questions = Q;
        }

    }
