        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) { 
            RadioButtonList1.DataSource = LoadAnswers();// calls this method. 
            RadioButtonList1.DataTextField = "Answers";// set  texts field to the answers 
            RadioButtonList1.DataValueField = "QuestionID";//set values to the questionID
            RadioButtonList1.DataBind();
            counter = 0;// set the counter to 0 
            Session["counter"] = counter;
            List<Questions> RandomQuestion = (List<Questions>)Session["RandomQuestion"];
   
            Question.Text = RandomQuestion[counter].q;
            Test.Text = Session["TestID"].ToString();// set the textBox to the value that is stored in the TestID session
            



           
                }
           
        }
        
        public List<Answer> LoadAnswers()
        {
            
            string ID = Session["TestID"].ToString();// assign th session values into ID
            List<String> A = DB.getQuestioninTest(ID);// use the getQuestioninTest methods and assign it to A 
            string connString;

            List<Answer> answer = new List<Answer>();
            connString = @"Provider=Microsoft.JET.OLEDB.4.0;Data Source=I:\AWD\WebApplication1\cwDBExample.mdb";
            OleDbConnection myConnection = new OleDbConnection(connString);

            string myQuery = "SELECT answer FROM testAnswer WHERE questionId ='" + A + "'";// finds answer with the same values as A 
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);
            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    Answer r = new Answer(int.Parse(myReader["questionId"].ToString()), myReader["answer"].ToString());
                    answer.Add(r);
                }
                return answer;
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

        protected void Next_Click(object sender, EventArgs e)
        {
            counter = int.Parse(Session["counter"].ToString());

            List<Questions> QuestionCount = (List<Questions>)Session["RandomQuestion"] ;

         
          

            counter += 1;// counter + 1
            Session["counter"] = counter;// stores it in the counter session 


            if (counter >= QuestionCount.Count)// check if counter is greater or equal then the number of Questions. 
            {
                Response.Redirect("TestPage");// if so, go to the TestPage
            }
            else
            {

                Test.Text = Session["TestID"].ToString();// else set test to the value of the TestID session. 
            }
        }
