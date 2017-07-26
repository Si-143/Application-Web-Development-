  public class testQuestion
    {
        
        string Quest;
        int points;
        string instr;
        Course cID;
        test testID;
        Questions questioned

        public Questions QuestionID
        {
            get { return questionID; }
            set { questionID = value; }
        }


        public string quest
        {
            get { return Quest; }
            set { Quest = value; }
        }
        

        public test TestID
        {
            get { return testID; }
            set { testID = value; }
        }
        

        public int Points
        {
            get { return points; }
            set { points = value; }
        }
        

        public string Instr
        {
            get { return instr; }
            set { instr = value; }
        }
        

        public Course CID
        {
            get { return cID; }
            set { cID = value; }
        }
        public testQuestion (string Q, int p, string I, Course C,test tID, Questions qID)
        {
            questionID = qID;
            Quest = Q;
            testID = tID;
            points = p;
           
            instr = I;
            cID = C
