using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PyLearn
{
    public partial class Student : System.Web.UI.Page
    {
        User user;
        List<string> progressDB;
        List<string> studentsDB;
        List<string> finalDB;
        List<string> errorsDB;

        int counter = 1;
        int counter2 = 1;
        int counter3 = 1;
        int counterID = 1; 
        int counterID2 = 1; 
        int counterID3 = 1; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Contents.Count == 0) //user is not supposed to use this webform, redirect to index
                Response.Redirect("Login.aspx");
            else
            {
                if ((string)HttpContext.Current.Session["UserType"] != null)
                {
                    if (((string)HttpContext.Current.Session["UserType"]).Equals("True"))
                        Response.Redirect("Teacher.aspx");
                }
                //usernamel.InnerText = "Hi " + (string)HttpContext.Current.Session["Username"];
                usernameLabel.InnerText = (string)HttpContext.Current.Session["Username"];
            }

            user = new User((string)HttpContext.Current.Session["Username"]);


            studentsDB = Auxiliary.GetStudentsFromDB(user.username);
            if (studentsDB == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Students could not be loaded. Please contact us about this error. ')", true);
                return;
            }

            TableRow row1 = new TableRow();
            foreach (string s in studentsDB)
            {
                TableCell cell1 = new TableCell();

                cell1.Text = s;
                row1.Cells.Add(cell1);
                if (counter == 2)
                {
                    counter = 0;
                    
                    Table1.Rows.Add(row1);
                    row1 = new TableRow();
                }
                counter++;
            }


            progressDB = Auxiliary.GetOneProgressFromDB();
            if (progressDB == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Progress could not be loaded. Please contact us about this error. ')", true);
                return;
            }

            TableRow row2 = new TableRow();
            foreach (string s in progressDB)
            {
                TableCell cell1 = new TableCell();

                cell1.Text = s;
                row2.Cells.Add(cell1);
                if (counter2 == 13)
                {
                    counter2 = 0;
                   
                    Table2.Rows.Add(row2);
                    row2 = new TableRow();
                }
                counter2++;
            }


            finalDB = Auxiliary.GetOnesFinalTestProgressFromDB();
            if (finalDB == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Final test rogress could not be loaded. Please contact us about this error. ')", true);
                return;
            }

            TableRow row3 = new TableRow();
            foreach (string s in finalDB)
            {
                TableCell cell1 = new TableCell();

                cell1.Text = s;
                row3.Cells.Add(cell1);
                if (counter3 == 14)
                {
                    counter3 = 0;

                    Table3.Rows.Add(row3);
                    row3 = new TableRow();
                }
                counter3++;
            }

            errorsDB = Auxiliary.GetErrors();
            syntaxErrorLabel.InnerText = errorsDB[0];
            logicalErrorLabel.InnerText = errorsDB[1];
            combErrorLabel.InnerText = errorsDB[2];
            string chapters = "";
            if (Int32.Parse(errorsDB[3]) > 3)
            {
                chapters = chapters + "1";
                System.Diagnostics.Debug.WriteLine("CHAPTER 1 " + Int32.Parse(errorsDB[3]));
            }
            if (Int32.Parse(errorsDB[4]) > 3)
            {
                chapters = chapters + "2";
                System.Diagnostics.Debug.WriteLine("CHAPTER 2 " + Int32.Parse(errorsDB[4]));
            }
            if (Int32.Parse(errorsDB[5]) > 3)
            {
                chapters = chapters + "3";
                System.Diagnostics.Debug.WriteLine("CHAPTER 3 " + Int32.Parse(errorsDB[5]));
            }
            string finalChapters = "";
            foreach (char i in chapters)
            {
                finalChapters = finalChapters + i + ",";
            }
            
            if (String.IsNullOrEmpty(finalChapters))
            {
                chapterErrors.InnerText = "Κανένα";

            }
            else
            {
                finalChapters = finalChapters.Remove(finalChapters.Length - 1);
                chapterErrors.InnerText = "Κεφάλαιο " + finalChapters;
            }
        }

    }
}