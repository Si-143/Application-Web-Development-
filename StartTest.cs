protected void Page_Load(object sender, EventArgs e)
{
Testid.DataSource = DB.ListTest(); Testid.DataTextField = "TestName";
Testid.DataValueField = "TestID";
Testid.DataBind();
Session["TestID"] = Testid.SelectedValue;
string TId = Session["TestID"].ToString();
}
 protected void Submit_Click(object sender, EventArgs e)
 {
 string connString = @"Provider=Microsoft.JET.OLEDB.4.0;Data
 Source=I:\AWD\WebApplication1\cwDBExample.mdb"; // pathing of the database
 OleDbConnection myConnection = new OleDbConnection(connString);
 string myQuery = "SELECT * FROM test WHERE password = '" +
 Pass.Text + "'";// select all from the test table where the password match with
 each other,
 OleDbCommand myCommand = new OleDbCommand(myQuery,
 myConnection);
 try
 {
 myConnection.Open();
 OleDbDataReader reader = myCommand.ExecuteReader();
 if (reader.HasRows == true)// check if it is true
 {
int T = Int32.Parse(Testid.SelectedValue.ToString());
List<Questions> question = DB.LoadQuestion(T);// set
question to the value that is returned from loadQuestion method.
Random r = new Random();// randomiser
List<Questions> RandomQuestion = new List<Questions>();
while (RandomQuestion.Count < 5)// check the
randomquestion count is less then 5
{
int num = r.Next(question.Count);
bool containsQuestion = false;
foreach (var Q in RandomQuestion)
{
if (question[num] == Q)
{
containsQuestion = true;
}
}
if (!containsQuestion)
{
RandomQuestion.Add(question[num]);
}
 }
 Session["RandomQuestion"] = RandomQuestion;
Response.Redirect("TestPage");
output.Text = "Successful";
}
else
{
output.Text = "Incorrect User Or Pass";
}
}
catch (Exception ex)
{
Pass.Text + "'";
}
myQuery = "SELECT * FROM test WHERE password = '" +
output.Text = "Error";
finally
{
}
myConnection.Close();
}
