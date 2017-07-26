protected void Page_Load(object sender, EventArgs e)
{

if (!Page.IsPostBack) {
RadioButtonList1.DataSource = LoadAnswers();// calls this method. RadioButtonList1.DataTextField = "Answers";// set texts field to the answers
RadioButtonList1.DataValueField = "QuestionID";//set values to the
questionID
RadioButtonList1.DataBind();
counter = 0;// set the counter to 0
Session["counter"] = counter;
List<Questions> RandomQuestion =
(List<Questions>)Session["RandomQuestion"];
TestPage code
 Question.Text = RandomQuestion[counter].q;
 Test.Text = Session["TestID"].ToString();// set the textBox to the
 value that is stored in the TestID session
} }
 public List<Answer> LoadAnswers()
  string ID = Session["TestID"].ToString();// assign th session
  List<String> A = DB.getQuestioninTest(ID);// use the
 getQuestioninTest methods and assign it to A
 string connString;
 List<Answer> answer = new List<Answer>();
 connString = @"Provider=Microsoft.JET.OLEDB.4.0;Data
 Source=I:\AWD\WebApplication1\cwDBExample.mdb";
 
