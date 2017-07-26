public class DB
    {
        
        private static OleDbConnection GetConnection()
        {
            string connString;

            connString = @"Provider=Microsoft.JET.OLEDB.4.0;Data Source=I:\AWD\WebApplication1\cwDBExample.mdb";
            return new OleDbConnection(connString);
        }
       // method to find the database. 
    


        public static void addquestions(string Q, int points, string I, int testID,int C)
        {
            
            OleDbConnection myConnection = GetConnection();// call the get Connection method. 
            string myQuery = "INSERT INTO testQuestion( [question], [points], [instructions],[courseId] ,[testId]) VALUES ( '" + Q + "' , '" + points + "' , '" + I + "' , '"+ C + "' , '" + testID + "')";// uses the variables to add them into the testQuestion table. 
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();// open connection.
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
            }
            finally
            {
                myConnection.Close();// close connection 
            }
        }

        public static List<Questions> ListQuestions()
        {
            List<Questions> question = new List<Questions>();// assign the values in list Question to question 
            OleDbConnection myConnection = GetConnection();

            string myQuery = "SELECT questionId, question FROM testQuestion";// select table. 
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);
            
            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Questions q = new Questions(int.Parse(myReader["questionId"].ToString()), myReader["question"].ToString());// inserts it back into q 
                    question.Add(q);// add q into question
                }
                return question;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error", ex);
                return null;
            }
            finally
            {
                myConnection.Close();
            }
        }
        public static List<testQuestion> LoadTestQuestion(int TId)// same method as list questions but check if testId matches with TId variable. 
        {
            List<testQuestion> listofTest = new List<testQuestion>();
            OleDbConnection myConnection = GetConnection();
           
            string myQuery = "SELECT questionId,question,testId,points,instructions,courseId FROM testQuestion WHERE testId=" + TId;
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);
            List<Course> course = ListCourse();
            List<Questions> quest = ListQuestions();
            List<test> test1 = ListTest();
            // calling the lists 
            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    Course TestCourse = findCourse(course, int.Parse(myReader["courseId"].ToString()));// uses value from the table row "courseId"
                    Questions TestQuestion = findTestQuestion(quest, int.Parse(myReader["question"].ToString()));// same process but with "question"
                    test Testname = findTest(test1, int.Parse(myReader["testId"].ToString()));// same process but with "testId"
                    testQuestion T = new testQuestion(myReader["question"].ToString(), int.Parse(myReader["point"].ToString()),myReader["instructions"].ToString(),TestCourse,Testname,TestQuestion);// assign all the values into the testQuestion T list.
                    listofTest.Add(T);// stores it. 
                }
                return listofTest;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return null;
                
            }
            finally
            {
                myConnection.Close();
            }
        }
        private static Questions findQuestionID(List<Questions> qId, int QId)
        {
            foreach (var QIdList in qId)
            {
                if (QIdList.qID == QId)// check if they are equal.
                {
                    return QIdList;// if return QIdList
                }
            }
            return null;
        }

        private static Questions findTestQuestion(List<Questions> fTQ, int QId)
        {
            foreach (var testList in fTQ)
            {
                if (testList.qID == QId)
                {
                    return testList;
                }
            }
            return null;
        }// same method as above but with different variables 

        public static List<Questions> LoadQuestion(int T)// 
        {
            List<Questions> Q = new List<Questions>();
            OleDbConnection myConnection = GetConnection();
            string myQuery = "SELECT questionId, question, testId FROM testQuestion WHERE testId = " + T;// select questionId, question and testId from the testQuestion table, checks if testId matches with T
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

            

            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                  
                    Questions v = new Questions(int.Parse(myReader["questionId"].ToString()), myReader["question"].ToString());// stores them in v 
                    Q.Add(v);// v is added to Q.
                }
                return Q;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return null;
            }
            finally
            {
                myConnection.Close();
            }
        }
        private static test findTest(List<test> ftest, int tID)// same method as find QuestionId
        {
            foreach (var fTest in ftest)
            {
                if (fTest.TestID == tID)
                {
                    return fTest;
                }
            }
            return null;
        }

        private static Course findCourse(List<Course> fCourse, int TestID)// same method as findtest
        {
            foreach (var C in fCourse)
            {
                if (C.CourID == TestID)
                {
                    return C;
                }
            }
            return null;
        }
        public static List<String> getQuestioninTest(string ID )
        {
            List<String> GetTest = new List<String>();
            OleDbConnection myConnection = GetConnection();
            string myQuery = "SELECT questionId FROM testQuestion WHERE testId ='" + ID + "'";// select questionId from testQuestion and checks if testId matches with ID
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    GetTest.Add(myReader["testId"].ToString() +  myReader["questionId"].ToString());// add them to getTest
                }
                return GetTest;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return null;
            }
            finally
            {
                myConnection.Close();
            }
        }
        

        public static List<test> ListTest()
        {
            List<test> TestList = new List<test>();// uses the list and store it in TestList
            OleDbConnection myConnection = GetConnection();

            string myQuery = "SELECT testId, testName FROM test";// select the testId and testName from test
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    test t = new test(int.Parse(myReader["testId"].ToString()), myReader["testName"].ToString());// add them to t
                    TestList.Add(t);// t is added to TestList
                }
                return TestList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error", ex);
                return null;
            }
            finally
            {
                myConnection.Close();
            }
        }
        public static List<Course> ListCourse()// same method as List Test. 
        {
            List<Course> course = new List<Course>();
            OleDbConnection myConnection = GetConnection();

            string myQuery = "SELECT * FROM course";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Course c = new Course(int.Parse(myReader["courseId"].ToString()), myReader["courseName"].ToString());
                    course.Add(c);
                }
                return course;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error", ex);
                return null;
            }
            finally
            {
                myConnection.Close();
            }
        }




        
        public static int GetCourseID(string C)
        {
            int CourseID;
            OleDbConnection myConnection = GetConnection();

            string myQuery = "SELECT * FROM testQuestion WHERE [courseId] = '" + C + "'";// check if courssId matches with C
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                OleDbDataReader myreader = myCommand.ExecuteReader();
                myreader.Read();
                CourseID = int.Parse(myreader["courseId"].ToString());// adds the values from the database into the CourseID
                return CourseID;// return CourseID
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return -1;
            }
            finally
            {
                myConnection.Close();
            }
        }
        public static int getQID(string Q)// same method as GetCourseID 
        {
            int questionID;
            OleDbConnection myConnection = GetConnection();

            string myQuery = "SELECT questionId FROM testQuestion WHERE [question] = '"+ Q + "'";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                OleDbDataReader myreader = myCommand.ExecuteReader();
                myreader.Read();
                questionID = int.Parse(myreader["questionId"].ToString() );
                return questionID;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return -1;
            }
            finally
            {
                myConnection.Close();
            }
        }
        
        public static string addanswer(string Q, int correct, string Getid)// get the values from the add question page 
        {
            int myid = getQID(Getid);// again the getQID into myid
            OleDbConnection myConnection = GetConnection();

            string myQuery = "INSERT INTO testAnswer( [answer], [questionId] ,[correct] ) VALUES ( '" + Q + "' , '" + myid + "' , '" + correct + "')";// inserts the values into the correct rows. 
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                return "works";//return this message if it was successful
            }
            catch (Exception ex)
            {
                return myid.ToString();
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static void Register(string N, string E, string U, string P)// same method as addanswers but with different variables and table. 
    {
        OleDbConnection myConnection = GetConnection();
        
    string myQuery = "INSERT INTO student( [fullName], [userEmail], [username], [password])VALUES ( '" + N + "' , '" + E + "' , '" + U + "' , '"+ P + "')"; 

  OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

  try {
     myConnection.Open();
     myCommand.ExecuteNonQuery();
           Console.WriteLine("successful registration") ;
  }
  catch (Exception ex)  {
      Console.WriteLine("Exception in DBHandler",ex);
  }
  finally  {
      myConnection.Close();
      Console.WriteLine("error");
  }
    }
        
