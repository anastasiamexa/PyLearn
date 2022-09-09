using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PyLearn
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear(); //clear session variables 
        }

        protected void LogInButton_Click(object sender, EventArgs e)
        {
            //Check if user's input is valid
            string notification = Auxiliary.IsValidUserInputLogIn(Username.Text.Trim(), Password.Text.Trim());
            if (notification != null)
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + notification + "')", true);
            else
            {
                User user = new User(Username.Text.Trim());
                //Check if user's credentials match a dababase record
                notification = user.AuthenticateCredentials(Password.Text.Trim());
                if (notification != null)
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + notification + "')", true);
                else
                {
                    //Check if user is admin
                    string isAdmin = user.IsAdmin();
                    if (isAdmin != null)
                    {
                        Session["Username"] = user.username;
                        Session["UserType"] = isAdmin;
                        if (isAdmin.Equals("True"))
                            Response.Redirect("Teacher.aspx");
                        else if (isAdmin.Equals("False"))
                            Response.Redirect("Student.aspx");
                    }
                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' An exeption was caught.Please report it. ')", true);
                }
            }
        }
    }
}