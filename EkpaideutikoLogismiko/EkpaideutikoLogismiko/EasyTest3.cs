using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EkpaideutikoLogismiko
{
    public partial class EasyTest3 : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);
        List<Object> questions = new List<Object>(); // List containing multiple choice and true false questions
        List<object> rquestions; // The same list as before but now its contents are shuffled
        List<int> qids = new List<int>(); // List containing the ids of the questions
        List<string> answers = new List<string>(); // List containing the user's answers
        List<string> rightAnswers = new List<string>(); // List containing the right answers
        bool flag; // Variable showing the type of question
        int i = 1;
        string username = "";
        bool isCheck = true;


        public EasyTest3(string u)
        {
            InitializeComponent();
            username = u;
            // Generate random number of multiple choice and true false questions
            // The total number of questions is always 5
            Random rnd = new Random();
            // Creates a number between 1 and 4
            int random_true_false = rnd.Next(1, 5);  // Random number of true false questions
            int random_multiple_choice = 5 - random_true_false; // The remaining questions are of type multiple choice

            // Retrieve the multiple choice questions from database
            string query = "select * from multiplechoice inner join questions on multiplechoice.id= questions.id where chapter=3";
            List<MultipleChoice> multipleChoiseList = new List<MultipleChoice>(); // List containing all of the multiple choice questions
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(Auxiliary.CONNECTION_STRING);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataReader dataReader = command.ExecuteReader(); // Run query                    

                while (dataReader.Read())
                {
                    // Create a MultipleChoice object and set the attribute values according to database
                    MultipleChoice multiple = new MultipleChoice(Int32.Parse(dataReader[0].ToString()), dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString(), dataReader[4].ToString(), dataReader[5].ToString(), Int32.Parse(dataReader[6].ToString()));
                    // Add the object to the list
                    multipleChoiseList.Add(multiple);
                }
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Κάτι πήγε λάθος", "Αποτυχία", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Retrieve the true false questions from database
            string query2 = "select * from truefalse inner join questions on truefalse.id= questions.id where chapter=3";
            List<TrueFalse> trueFalseList = new List<TrueFalse>(); // List containing all of the true false questions
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(Auxiliary.CONNECTION_STRING);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query2, connection);
                NpgsqlDataReader dataReader = command.ExecuteReader(); // Run query                    

                while (dataReader.Read())
                {
                    // Create a TreuFalse object and set the attribute values according to database
                    TrueFalse trueFalse = new TrueFalse(Int32.Parse(dataReader[0].ToString()), dataReader[1].ToString(), bool.Parse(dataReader[2].ToString()));
                    // Add the object to the list
                    trueFalseList.Add(trueFalse);
                }
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Κάτι πήγε λάθος", "Αποτυχία", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Shuffle lists and take the first n random elements of each list
            var rmultipleChoiseList = multipleChoiseList.OrderBy(item => rnd.Next()).Take(random_multiple_choice);
            var rtrueFalseList = trueFalseList.OrderBy(item => rnd.Next()).Take(random_true_false);

            System.Diagnostics.Debug.WriteLine(rmultipleChoiseList.Count());
            System.Diagnostics.Debug.WriteLine(rtrueFalseList.Count());
            System.Diagnostics.Debug.WriteLine("-------------------------------");

            foreach (var i in rmultipleChoiseList)
            {
                // Add the multiple choice questions to the list of questions
                questions.Add(i);
                System.Diagnostics.Debug.WriteLine(i.id);
            }

            foreach (var i in rtrueFalseList)
            {
                // Add the true false questions to the list of questions
                questions.Add(i);
                System.Diagnostics.Debug.WriteLine(i.id);
            }

            // Shuffle the list of questions
            rquestions = questions.OrderBy(item => rnd.Next()).ToList();

            // Take the first question
            object o = new object();
            o = rquestions.ElementAt(0);
            // Check the question's type
            if (o.GetType().ToString().Equals("EkpaideutikoLogismiko.TrueFalse"))
            {
                flag = true;
                System.Diagnostics.Debug.WriteLine(o.GetType().ToString() + " ------------" + ((TrueFalse)o).id);
                question.Text = ((TrueFalse)o).question;
                first.Text = "Σωστό";
                second.Text = "Λάθος";
                third.Text = "";
                fourth.Text = "";
                third.Visible = false;
                fourth.Visible = false;
                qids.Add(((TrueFalse)o).id);
                rightAnswers.Add(((TrueFalse)o).answer.ToString());
                //System.Diagnostics.Debug.WriteLine(((TrueFalse)Convert.ChangeType(rquestions.ElementAt(0), typeof(TrueFalse))).id);
                //System.Diagnostics.Debug.WriteLine(((MultipleChoice)Convert.ChangeType(rquestions.ElementAt(0), typeof(MultipleChoice))).id);
            }
            else
            {
                flag = false;
                System.Diagnostics.Debug.WriteLine(o.GetType().ToString() + " ------------" + ((MultipleChoice)o).id);
                // Check if question is multiline
                List<string> tmp = new List<string>();
                tmp = ((MultipleChoice)o).question.Split('@').ToList();
                string s = "";
                foreach (string i in tmp)
                {
                    s = s + i + Environment.NewLine;
                    System.Diagnostics.Debug.WriteLine(i);
                }
                question.Text = s;
                first.Text = ((MultipleChoice)o).first;
                second.Text = ((MultipleChoice)o).second;
                if (String.IsNullOrEmpty(((MultipleChoice)o).third))
                {
                    third.Visible = false;
                }
                else
                {
                    third.Text = ((MultipleChoice)o).third;

                }
                if (String.IsNullOrEmpty(((MultipleChoice)o).fourth))
                {
                    fourth.Visible = false;
                }
                else
                {
                    fourth.Text = ((MultipleChoice)o).fourth;
                }
                qids.Add(((MultipleChoice)o).id);
                rightAnswers.Add(((MultipleChoice)o).answer.ToString());
            }
        }

        // Make the form movable
        private void EasyTest3_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void EasyTest3_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void EasyTest3_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        // Key shortcuts
        private void EasyTest3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.E)
            {
                exit.PerformClick();
            }

            if (e.Control == true && e.KeyCode == Keys.H)
            {
                help.PerformClick();
            }

            if (e.Control == true && e.KeyCode == Keys.B)
            {
                back.PerformClick();
            }
        }

        // Exit
        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Tool tips
        private void exit_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Έξοδος από την εφαρμογή (Ctrl + Ε)", exit);
        }

        private void help_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Βοήθεια (Ctrl + H)", help);
        }

        private void back_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Πίσω (Ctrl + B)", back);
        }

        private void back_Click(object sender, EventArgs e)
        {
            MainStudentMenu form = new MainStudentMenu(username);
            form.Show();
            this.Hide();
        }

        // Next question button
        private void button1_Click(object sender, EventArgs e)
        {
            if (isCheck)
            {
                if (flag)
                {
                    if (first.Checked == true)
                    {
                        answers.Add("True");
                    }
                    if (second.Checked == true)
                    {
                        answers.Add("False");
                    }
                    // If user's answer is correct
                    if (answers.Last().Equals(rightAnswers.Last()))
                    {
                        // If the correct answer is true
                        if (answers.Last().Equals("True"))
                        {
                            first.BackColor = Color.LightGreen;
                        }
                        // If the correct answer is false
                        else
                        {
                            second.BackColor = Color.LightGreen;
                        }
                    }
                    // If user's answer is wrong
                    else
                    {
                        // If the correct answer is false
                        if (answers.Last().Equals("True"))
                        {
                            first.BackColor = Color.Red;
                            second.BackColor = Color.LightGreen;
                        }
                        // If the correct answer is true
                        else
                        {
                            second.BackColor = Color.Red;
                            first.BackColor = Color.LightGreen;
                        }
                    }
                }
                else
                {
                    if (first.Checked == true)
                    {
                        answers.Add("1");
                    }
                    if (second.Checked == true)
                    {
                        answers.Add("2");
                    }
                    if (third.Checked == true)
                    {
                        answers.Add("3");
                    }
                    if (fourth.Checked == true)
                    {
                        answers.Add("4");
                    }

                    // If user's answer is correct
                    if (answers.Last().Equals(rightAnswers.Last()))
                    {
                        // If the correct answer is the first one
                        if (answers.Last().Equals("1"))
                        {
                            first.BackColor = Color.LightGreen;
                        }
                        // If the correct answer is the second one
                        else if (answers.Last().Equals("2"))
                        {
                            second.BackColor = Color.LightGreen;
                        }
                        // If the correct answer is the third one
                        else if (answers.Last().Equals("3"))
                        {
                            third.BackColor = Color.LightGreen;
                        }
                        // If the correct answer is the fourth one
                        else
                        {
                            fourth.BackColor = Color.LightGreen;
                        }
                    }
                    // If user's answer is wrong
                    else
                    {
                        // If the correct answer is the first one
                        if (rightAnswers.Last().Equals("1"))
                        {
                            first.BackColor = Color.LightGreen;
                            second.BackColor = Color.Crimson;
                            third.BackColor = Color.Crimson;
                            fourth.BackColor = Color.Crimson;
                        }
                        // If the correct answer is the second one
                        else if (rightAnswers.Last().Equals("2"))
                        {
                            second.BackColor = Color.LightGreen;
                            first.BackColor = Color.Crimson;
                            third.BackColor = Color.Crimson;
                            fourth.BackColor = Color.Crimson;

                        }
                        // If the correct answer is the third one
                        else if (rightAnswers.Last().Equals("3"))
                        {
                            third.BackColor = Color.LightGreen;
                            first.BackColor = Color.Crimson;
                            second.BackColor = Color.Crimson;
                            fourth.BackColor = Color.Crimson;
                        }
                        // If the correct answer is the fourth one
                        else
                        {
                            fourth.BackColor = Color.LightGreen;
                            first.BackColor = Color.Crimson;
                            second.BackColor = Color.Crimson;
                            third.BackColor = Color.Crimson;
                        }
                    }
                }
                isCheck = false;
                if (i == 5)
                {

                    button1.Text = "Τέλος";
                }
                else
                {
                    button1.Text = "Επόμενο";
                }
            }
            else
            {

                if (i == 5) // User answered all the questions go back to main menu
                {
                    // Calculate the results
                    int score = 0;
                    List<bool> scores = new List<bool>();
                    for (int i = 0; i < 5; i++)
                    {
                        if (answers.ElementAt(i).Equals(rightAnswers.ElementAt(i)))
                        {
                            score++;
                            scores.Add(true);
                        }
                        else
                        {
                            scores.Add(false);
                        }
                    }

                    // Write the results of the test to database
                    int rowsAffected = -1; // false value
                    string query = "insert into exercisehistory values (@username, @chapter, @difficulty, @id1, @id2, @id3, @id4, @id5, @answer1, @answer2, @answer3, @answer4, @answer5)" +
                        "on conflict (username, chapter, difficulty) do update set id1 = @id1,  id2 = @id2, id3 = @id3,  id4 = @id4, id5 = @id5,  answer1 = @answer1, answer2 = @answer2,  answer3 = @answer3, answer4 = @answer4, answer5 = @answer5";
                    try
                    {
                        NpgsqlConnection connection = new NpgsqlConnection(Auxiliary.CONNECTION_STRING);
                        connection.Open();
                        //define query's parameters
                        NpgsqlCommand command = new NpgsqlCommand(query, connection);
                        command.Parameters.AddWithValue("username", username);
                        command.Parameters.AddWithValue("chapter", 3);
                        command.Parameters.AddWithValue("difficulty", 0);
                        command.Parameters.AddWithValue("id1", qids.ElementAt(0));
                        command.Parameters.AddWithValue("id2", qids.ElementAt(1));
                        command.Parameters.AddWithValue("id3", qids.ElementAt(2));
                        command.Parameters.AddWithValue("id4", qids.ElementAt(3));
                        command.Parameters.AddWithValue("id5", qids.ElementAt(4));
                        command.Parameters.AddWithValue("answer1", scores.ElementAt(0));
                        command.Parameters.AddWithValue("answer2", scores.ElementAt(1));
                        command.Parameters.AddWithValue("answer3", scores.ElementAt(2));
                        command.Parameters.AddWithValue("answer4", scores.ElementAt(3));
                        command.Parameters.AddWithValue("answer5", scores.ElementAt(4));
                        rowsAffected = command.ExecuteNonQuery(); //run query
                        connection.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Κάτι πήγε λάθος", "Αποτυχία", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (rowsAffected == -1)
                    {
                        MessageBox.Show("Κάτι πήγε λάθος, ξαναπροσπάθησε αργότερα.", "Αποτυχία", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Η απάντησή σου καταχωρήθηκε!", "Επιτυχία", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        MainStudentMenu form = new MainStudentMenu(username);
                        form.Show();
                        this.Hide();
                    }

                    // Print messages
                    System.Diagnostics.Debug.WriteLine("********************************");
                    foreach (int i in qids)
                    {
                        System.Diagnostics.Debug.WriteLine("id: " + i.ToString());
                    }
                    System.Diagnostics.Debug.WriteLine("================================");
                    foreach (string s in answers)
                    {
                        System.Diagnostics.Debug.WriteLine("user ans: " + s);
                    }
                    System.Diagnostics.Debug.WriteLine("================================");
                    foreach (string s in rightAnswers)
                    {
                        System.Diagnostics.Debug.WriteLine("right ans: " + s);
                    }
                    System.Diagnostics.Debug.WriteLine("********************************");
                    System.Diagnostics.Debug.WriteLine(username + "'s score: " + score.ToString() + "/5");
                }
                else
                {
                    questionNumber.Text = "Ερώτηση " + (i + 1);
                    // Take the next question
                    object o = new object();
                    o = rquestions.ElementAt(i);
                    third.Visible = true;
                    fourth.Visible = true;
                    // Check the question's type
                    if (o.GetType().ToString().Equals("EkpaideutikoLogismiko.TrueFalse"))
                    {
                        System.Diagnostics.Debug.WriteLine(o.GetType().ToString() + " ------------" + ((TrueFalse)o).id);
                        flag = true;
                        question.Text = ((TrueFalse)o).question;
                        first.Text = "Σωστό";
                        second.Text = "Λάθος";
                        third.Visible = false;
                        third.Text = "";
                        fourth.Visible = false;
                        fourth.Text = "";
                        qids.Add(((TrueFalse)o).id);
                        rightAnswers.Add(((TrueFalse)o).answer.ToString());
                        //System.Diagnostics.Debug.WriteLine(((TrueFalse)Convert.ChangeType(rquestions.ElementAt(0), typeof(TrueFalse))).id);
                        //System.Diagnostics.Debug.WriteLine(((MultipleChoice)Convert.ChangeType(rquestions.ElementAt(0), typeof(MultipleChoice))).id);
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine(o.GetType().ToString() + " ------------" + ((MultipleChoice)o).id);
                        flag = false;
                        // Check if question is multiline
                        List<string> tmp = new List<string>();
                        tmp = ((MultipleChoice)o).question.Split('@').ToList();
                        string s = "";
                        foreach (string i in tmp)
                        {
                            s = s + i + Environment.NewLine;
                            System.Diagnostics.Debug.WriteLine(i);
                        }
                        question.Text = s;
                        first.Text = ((MultipleChoice)o).first;
                        second.Text = ((MultipleChoice)o).second;
                        if (String.IsNullOrEmpty(((MultipleChoice)o).third))
                        {
                            third.Visible = false;
                            third.Text = "";
                        }
                        else
                        {
                            third.Text = ((MultipleChoice)o).third;

                        }
                        if (String.IsNullOrEmpty(((MultipleChoice)o).fourth))
                        {
                            fourth.Visible = false;
                            fourth.Text = "";
                        }
                        else
                        {
                            fourth.Text = ((MultipleChoice)o).fourth;
                        }
                        qids.Add(((MultipleChoice)o).id);
                        rightAnswers.Add(((MultipleChoice)o).answer.ToString());
                    }
                    /*if (i == 4) // Last question reached
                    {
                        i++;
                    }
                    else
                    {
                        i++;
                    }*/
                    i++;
                }
                isCheck = true;
                // Reset colors
                first.BackColor = Color.Transparent;
                second.BackColor = Color.Transparent;
                third.BackColor = Color.Transparent;
                fourth.BackColor = Color.Transparent;
                button1.Text = "Έλεγχος";
            }
        }

        private void help_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "online_help.chm", HelpNavigator.TopicId, "35");
        }
    }
}
