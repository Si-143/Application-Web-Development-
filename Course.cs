    public class Course
    {
        int cID;
        string cName;   
        public int CourID{
            get {return cID;}
            set {cID = value;}
        }
        
          public string CourseName{
              get {return cName;}
              set {cName = value;}

        }
        public Course(int id,string CName)
        {
    cID = id;
    cName = CName;
