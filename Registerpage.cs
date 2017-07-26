        protected void Register_Click(object sender, EventArgs e)
        {
           
            string N = Name.Text;
            string U = User.Text;
            string P = Pass.Text;
            string E = Email.Text;
           // assign the textboxes into variables 
            if (Name.Text =="" || Pass.Text =="" || Pass.Text == "" || Email.Text == ""){// check if either the textboxs are blank. 
            Output.Text = ("try again");
            }
            else
            {
                DB.Register(N,E,U,P);// calls the register methods 
                Response.Redirect("Login");// redirect to the Login page with sucesssful 
            }

  
}
   
        }

        
    }
