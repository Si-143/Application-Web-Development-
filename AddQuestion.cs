public partial class Add_Questions : System.Web.UI.Page
    {
        List<string> test = new List<string>() {"1","2","3","4","5",};
        List<string> test2 = new List<string>() { "a", "b", "c", "d", "e" };
        List<TextBox> answerBox;
        List<RadioButton> buttons;
        List<CheckBox> CBox;

        protected void Page_Load(object sender, EventArgs e)
        {

            TestList.DataSource = DB.ListTest();
            TestList.DataTextField = "TestName";
            TestList.DataValueField = "TestID";
            TestList.DataBind();// use to ListTest method to fill the dropdown list 
        
            Courselist.DataSource = DB.ListCourse();
            Courselist.DataTextField = "CourseName";
            Courselist.DataValueField = "CourID";
            Courselist.DataBind();// same method but with course instead 
            if (IsPostBack)
            {
                   
                show();
            }
        }

        private void show()
        {
            if (MC.Checked)// if MC is checked then shows five radio buttons and TextBoxes 
            {
                RadioButton1.Text = test[0];
                RadioButton2.Text = test[1];
                RadioButton3.Text = test[2];
                RadioButton4.Text = test[3];
                RadioButton5.Text = test[4];
                answerBox = new List<TextBox>();
                answerBox.Add(TextBox1);
                answerBox.Add(TextBox2);
                answerBox.Add(TextBox3);
                answerBox.Add(TextBox4);
                answerBox.Add(TextBox5);
                buttons = new List<RadioButton>();
                buttons.Add(RadioButton1);
                buttons.Add(RadioButton2);
                buttons.Add(RadioButton3);
                buttons.Add(RadioButton4);
                buttons.Add(RadioButton5);
 

                RadioButton1.ID = test2[0];
                RadioButton2.ID = test2[1];
                RadioButton3.ID = test2[2];
                RadioButton4.ID = test2[3];
                RadioButton5.ID = test2[4];

                RadioButtonTable.Visible = true;
                CheckBoxTable.Visible = false;
            }
            else// else show 5 checkBoxes and textboxes instead 
            {
                CheckBox1.Text = test[0];
                CheckBox2.Text = test[1];
                CheckBox3.Text = test[2];
                CheckBox4.Text = test[3];
                CheckBox5.Text = test[4];
                answerBox = new List<TextBox>();
                answerBox.Add(TextBox6);
                answerBox.Add(TextBox7);
                answerBox.Add(TextBox8);
                answerBox.Add(TextBox9);
                answerBox.Add(TextBox10);
                CBox = new List<CheckBox>();
                CBox.Add(CheckBox1);
                CBox.Add(CheckBox2);
                CBox.Add(CheckBox3);
                CBox.Add(CheckBox4);
                CBox.Add(CheckBox5);

              

                CheckBox1.ID = test2[0];
                CheckBox2.ID = test2[1];
                CheckBox3.ID = test2[2];
                CheckBox4.ID = test2[3];
                CheckBox5.ID = test2[4];
                
                CheckBoxTable.Visible = true;
                RadioButtonTable.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            int C = int.Parse(Courselist.SelectedValue.ToString());
            string Q = Question.Text;
            
            string I = InsBox.Text;
            int testID = int.Parse(TestList.SelectedValue);
            // assign values into variables, to use in methods. 

            if (Question.Text == "" || Points.Text == "" ||InsBox.Text == "")
            {
                output.Text = ("Try again");
                Question.Text = "";
                Points.Text = "";
                InsBox.Text = "";
                //check if the textboxes are blank and if they are then clear the textboxes and display "try again"

            }
            else
            {
                int points = int.Parse(Points.Text);
                DB.addquestions(Q, points, I, testID, C);

            }
            for (int i = 0; i < 5; i++)// add five more buttons and textboxes. 
            {
                if (MC.Checked){// check is MC is ticked. 

                     //Label1.Text = DB.addanswer(answerBox[i].Text, Convert.ToInt32(buttons[i].Checked), Question.Text);
                    
                }

                    else{
                        DB.addanswer(answerBox[i].Text, Convert.ToInt32(CBox[i].Checked),Question.Text);// else do this method with combo boxes.
                            
                    }
                }


            
            
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            Response.Redirect("Add Questions");// reload up Add questions class
            

        }

        protected void AddTest_Click(object sender, EventArgs e)
        {
            string T = NewName.Text;
            string P = NewPass.Text;
            string connString;
            //assign them to variables. 

            connString = @"Provider=Microsoft.JET.OLEDB.4.0;Data Source=I:\AWD\WebApplication1\cwDBExample.mdb";// open connection
             OleDbConnection myConnection = new OleDbConnection(connString);
             string myQuery = "INSERT INTO test( [testName], [password]) VALUES ( '" + T + "' , '" + P +"')";// add variables into the database. 
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                Response.Redirect("Add Questions");// reloads the add question class 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);// show this message then errors appears 
            }
            finally
            {
                myConnection.Close();// close connection. 
            }
        }

        }
