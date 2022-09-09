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
    public partial class HardTest1 : Form
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
        int gaps;

        public HardTest1(string u)
        {
            InitializeComponent();
            username = u;
            // Generate random number of sequence and fillgap questions
            // The total number of questions is always 5
            Random rnd = new Random();
            // Creates a number between 1 and 4
            int random_sequence = rnd.Next(1, 5);  // Random number of sequence questions
            int random_fillGap = 5 - random_sequence; // The remaining questions are of type fillgap

            // Retrieve the fillgap questions from database
            string query = "select * from fillgap inner join questions on fillgap.id= questions.id where chapter=1";
            List<FillGap> fillGapList = new List<FillGap>(); // List containing all of the fillgap questions
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(Auxiliary.CONNECTION_STRING);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataReader dataReader = command.ExecuteReader(); // Run query                    

                while (dataReader.Read())
                {
                    // Create a FillGap object and set the attribute values according to database
                    FillGap fillGap = new FillGap(Int32.Parse(dataReader[0].ToString()), dataReader[1].ToString(), dataReader[2].ToString(), Int32.Parse(dataReader[3].ToString()));
                    // Add the object to the list
                    fillGapList.Add(fillGap);
                }
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Κάτι πήγε λάθος", "Αποτυχία", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Retrieve the sequence questions from database
            string query2 = "select * from sequence inner join questions on sequence.id= questions.id where chapter=1";
            List<Sequence> sequenceList = new List<Sequence>(); // List containing all of the sequence questions
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(Auxiliary.CONNECTION_STRING);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query2, connection);
                NpgsqlDataReader dataReader = command.ExecuteReader(); // Run query                    

                while (dataReader.Read())
                {
                    // Create a Sequence object and set the attribute values according to database
                    Sequence sequence = new Sequence(Int32.Parse(dataReader[0].ToString()), dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString(), dataReader[4].ToString(), dataReader[5].ToString(), dataReader[6].ToString(), dataReader[7].ToString(), dataReader[8].ToString());
                    // Add the object to the list
                    sequenceList.Add(sequence);
                }
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Κάτι πήγε λάθος", "Αποτυχία", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Shuffle lists and take the first n random elements of each list
            var rfillGapList = fillGapList.OrderBy(item => rnd.Next()).Take(random_fillGap);
            var rsequenceList = sequenceList.OrderBy(item => rnd.Next()).Take(random_sequence);

            System.Diagnostics.Debug.WriteLine(rfillGapList.Count());
            System.Diagnostics.Debug.WriteLine(rsequenceList.Count());
            System.Diagnostics.Debug.WriteLine("-------------------------------");

            foreach (var i in rfillGapList)
            {
                // Add the fill gap questions to the list of questions
                questions.Add(i);
                System.Diagnostics.Debug.WriteLine(i.id);
            }

            foreach (var i in rsequenceList)
            {
                // Add the sequence questions to the list of questions
                questions.Add(i);
                System.Diagnostics.Debug.WriteLine(i.id);
            }

            // Shuffle the list of questions
            rquestions = questions.OrderBy(item => rnd.Next()).ToList();

            // Take the first question
            object o = new object();
            o = rquestions.ElementAt(0);
            // Check the question's type
            if (o.GetType().ToString().Equals("EkpaideutikoLogismiko.Sequence"))
            {
                first.Visible = true;
                second.Visible = true;
                third.Visible = true;
                fourth.Visible = true;
                fifth.Visible = true;
                sixth.Visible = true;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                flag = true;
                System.Diagnostics.Debug.WriteLine(o.GetType().ToString() + " ------------" + ((Sequence)o).id);
                question.Text = ((Sequence)o).question;
                first.Text = "1: " + ((Sequence)o).first;
                second.Text = "2: " + ((Sequence)o).second;
                third.Text = "3: " + ((Sequence)o).third;
                if (String.IsNullOrEmpty(((Sequence)o).fourth))
                {
                    fourth.Visible = false;
                }
                else
                {
                    fourth.Visible = true;
                    fourth.Text = "4: " + ((Sequence)o).fourth;
                }
                if (String.IsNullOrEmpty(((Sequence)o).fifth))
                {
                    fifth.Visible = false;
                }
                else
                {
                    fifth.Visible = true;
                    fifth.Text = "5: " + ((Sequence)o).fifth;
                }
                if (String.IsNullOrEmpty(((Sequence)o).sixth))
                {
                    sixth.Visible = false;
                }
                else
                {
                    sixth.Visible = true;
                    sixth.Text = "6: " + ((Sequence)o).sixth;
                }
                qids.Add(((Sequence)o).id);
                rightAnswers.Add(((Sequence)o).answer.ToString());
                //System.Diagnostics.Debug.WriteLine(((TrueFalse)Convert.ChangeType(rquestions.ElementAt(0), typeof(TrueFalse))).id);
                //System.Diagnostics.Debug.WriteLine(((MultipleChoice)Convert.ChangeType(rquestions.ElementAt(0), typeof(MultipleChoice))).id);
            }
            else
            {
                first.Visible = false;
                second.Visible = false;
                third.Visible = false;
                fourth.Visible = false;
                fifth.Visible = false;
                sixth.Visible = false;
                flag = false;
                System.Diagnostics.Debug.WriteLine(o.GetType().ToString() + " ------------" + ((FillGap)o).id);
                // Check if question is multiline
                List<string> tmp = new List<string>();
                tmp = ((FillGap)o).question.Split('@').ToList();
                string s = "";
                foreach (string i in tmp)
                {
                    s = s + i + Environment.NewLine;
                    System.Diagnostics.Debug.WriteLine(i);
                }
                question.Text = s;
                gaps = ((FillGap)o).gaps;
                switch (gaps){
                    case 1:
                        textBox1.Visible = true;
                        textBox2.Visible = false;
                        textBox3.Visible = false;
                        textBox4.Visible = false;
                        label1.Visible = true;
                        label2.Visible = false;
                        label3.Visible = false;
                        label4.Visible = false;
                        break;
                    case 2:
                        textBox1.Visible = true;
                        textBox2.Visible = true;
                        textBox3.Visible = false;
                        textBox4.Visible = false;
                        label1.Visible = true;
                        label2.Visible = true;
                        label3.Visible = false;
                        label4.Visible = false;
                        break;
                    case 3:
                        textBox1.Visible = true;
                        textBox2.Visible = true;
                        textBox3.Visible = true;
                        textBox4.Visible = false;
                        label1.Visible = true;
                        label2.Visible = true;
                        label3.Visible = true;
                        label4.Visible = false;
                        break;
                    case 4:
                        textBox1.Visible = true;
                        textBox2.Visible = true;
                        textBox3.Visible = true;
                        textBox4.Visible = true;
                        label1.Visible = true;
                        label2.Visible = true;
                        label3.Visible = true;
                        label4.Visible = true;
                        break;
                }
                qids.Add(((FillGap)o).id);
                rightAnswers.Add(((FillGap)o).answer.ToString());
            }
        }

        // Make the form movable
        private void HardTest1_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void HardTest1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void HardTest1_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        // Key shortcuts
        private void HardTest1_KeyDown(object sender, KeyEventArgs e)
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
                if (!flag)   // If fill gap
                {
                    string message = "";
                    string answer = "";
                    // Get user's input
                    if (String.IsNullOrEmpty(textBox1.Text.ToString()) && textBox1.Visible == true)
                    {
                        message = message + " 1";
                    }
                    else if(textBox1.Visible == true)
                    {
                        answer = answer + textBox1.Text.ToString() + ",";
                    }
                    if (String.IsNullOrEmpty(textBox2.Text.ToString()) && textBox2.Visible == true)
                    {
                        message = message + " 2";
                    }
                    else if (textBox2.Visible == true)
                    {
                        answer = answer + textBox2.Text.ToString() + ",";
                    }
                    if (String.IsNullOrEmpty(textBox3.Text.ToString()) && textBox3.Visible == true)
                    {
                        message = message + " 3";
                    }
                    else if (textBox3.Visible == true)
                    {
                        answer = answer + textBox3.Text.ToString() + ",";
                    }
                    if (String.IsNullOrEmpty(textBox4.Text.ToString()) && textBox4.Visible == true)
                    {
                        message = message + " 4";
                    }
                    else if (textBox4.Visible == true)
                    {
                        answer = answer + textBox4.Text.ToString();
                    }
                    // Check if user has filled all fields
                    if (!String.IsNullOrEmpty(message))
                    {
                        MessageBox.Show("Συμπλήρωσε κείμενο στα πεδία" + message, "Αποτυχία", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (answer.Last().Equals(','))
                        {
                            answers.Add(answer.Remove(answer.Length - 1));
                        }
                        else
                        {
                            answers.Add(answer);
                        }
                    }
                    // If user's answer is correct
                    if (answers.Last().Equals(rightAnswers.Last()))
                    {
                        textBox1.BackColor = Color.LightGreen;
                        textBox2.BackColor = Color.LightGreen;
                        textBox3.BackColor = Color.LightGreen;
                        textBox4.BackColor = Color.LightGreen;
                    }
                    // If user's answer is wrong
                    else
                    {
                        String[] usersAnswer = answers.Last().Split(',');
                        String[] rightAnswer = rightAnswers.Last().Split(',');
                        TextBox[] tbs = { textBox1, textBox2, textBox3, textBox4 };
                        for (int i = 0; i<gaps; i++)
                        {
                            System.Diagnostics.Debug.WriteLine(usersAnswer[i] + "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!" + rightAnswer[i]);
                            if (usersAnswer[i].Equals(rightAnswer[i]))
                            {
                                tbs[i].BackColor = Color.LightGreen;
                            }
                            else
                            {
                                tbs[i].BackColor = Color.Crimson;
                            }
                        }
                    }
                }
                else   // If sequence
                {
                    if (String.IsNullOrEmpty(textBox1.Text.ToString()))
                    {
                        MessageBox.Show("Συμπλήρωσε κείμενο στο πεδίο", "Αποτυχία", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        answers.Add(textBox1.Text.ToString());
                    }

                    // If user's answer is correct
                    if (answers.Last().Equals(rightAnswers.Last()))
                    {
                        textBox1.BackColor = Color.LightGreen;
                    }
                    // If user's answer is wrong
                    else
                    {
                        textBox1.BackColor = Color.Crimson;
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
                        command.Parameters.AddWithValue("chapter", 1);
                        command.Parameters.AddWithValue("difficulty", 1);
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
                    if (o.GetType().ToString().Equals("EkpaideutikoLogismiko.Sequence"))
                    {
                        first.Visible = true;
                        second.Visible = true;
                        third.Visible = true;
                        fourth.Visible = true;
                        fifth.Visible = true;
                        sixth.Visible = true;

                        label2.Visible = false;
                        label3.Visible = false;
                        label4.Visible = false;
                        textBox2.Visible = false;
                        textBox3.Visible = false;
                        textBox4.Visible = false;
                        System.Diagnostics.Debug.WriteLine(o.GetType().ToString() + " ------------" + ((Sequence)o).id);
                        flag = true;
                        question.Text = ((Sequence)o).question;
                        first.Text = "1: " + ((Sequence)o).first;
                        second.Text = "2: " + ((Sequence)o).second;
                        third.Text = "3: " + ((Sequence)o).third;
                        if (String.IsNullOrEmpty(((Sequence)o).fourth))
                        {
                            fourth.Visible = false;
                        }
                        else
                        {
                            fourth.Visible = true;
                            fourth.Text = "4: " + ((Sequence)o).fourth;
                        }
                        if (String.IsNullOrEmpty(((Sequence)o).fifth))
                        {
                            fifth.Visible = false;
                        }
                        else
                        {
                            fifth.Visible = true;
                            fifth.Text = "5: " + ((Sequence)o).fifth;
                        }
                        if (String.IsNullOrEmpty(((Sequence)o).sixth))
                        {
                            sixth.Visible = false;
                        }
                        else
                        {
                            sixth.Visible = true;
                            sixth.Text = "6: " + ((Sequence)o).sixth;
                        }
                        qids.Add(((Sequence)o).id);
                        rightAnswers.Add(((Sequence)o).answer.ToString());
                        //System.Diagnostics.Debug.WriteLine(((TrueFalse)Convert.ChangeType(rquestions.ElementAt(0), typeof(TrueFalse))).id);
                        //System.Diagnostics.Debug.WriteLine(((MultipleChoice)Convert.ChangeType(rquestions.ElementAt(0), typeof(MultipleChoice))).id);
                    }
                    else
                    {
                        first.Visible = false;
                        second.Visible = false;
                        third.Visible = false;
                        fourth.Visible = false;
                        fifth.Visible = false;
                        sixth.Visible = false;
                        System.Diagnostics.Debug.WriteLine(o.GetType().ToString() + " ------------" + ((FillGap)o).id);
                        flag = false;
                        // Check if question is multiline
                        List<string> tmp = new List<string>();
                        tmp = ((FillGap)o).question.Split('@').ToList();
                        string s = "";
                        foreach (string i in tmp)
                        {
                            s = s + i + Environment.NewLine;
                            System.Diagnostics.Debug.WriteLine(i);
                        }
                        question.Text = s;
                        gaps = ((FillGap)o).gaps;
                        switch (gaps)
                        {
                            case 1:
                                textBox1.Visible = true;
                                textBox2.Visible = false;
                                textBox3.Visible = false;
                                textBox4.Visible = false;
                                label1.Visible = true;
                                label2.Visible = false;
                                label3.Visible = false;
                                label4.Visible = false;
                                break;
                            case 2:
                                textBox1.Visible = true;
                                textBox2.Visible = true;
                                textBox3.Visible = false;
                                textBox4.Visible = false;
                                label1.Visible = true;
                                label2.Visible = true;
                                label3.Visible = false;
                                label4.Visible = false;
                                break;
                            case 3:
                                textBox1.Visible = true;
                                textBox2.Visible = true;
                                textBox3.Visible = true;
                                textBox4.Visible = false;
                                label1.Visible = true;
                                label2.Visible = true;
                                label3.Visible = true;
                                label4.Visible = false;
                                break;
                            case 4:
                                textBox1.Visible = true;
                                textBox2.Visible = true;
                                textBox3.Visible = true;
                                textBox4.Visible = true;
                                label1.Visible = true;
                                label2.Visible = true;
                                label3.Visible = true;
                                label4.Visible = true;
                                break;
                        }
                        qids.Add(((FillGap)o).id);
                        rightAnswers.Add(((FillGap)o).answer.ToString());
                    }
                    i++;
                }
                isCheck = true;
                // Reset colors
                textBox1.BackColor = SystemColors.Window;
                textBox2.BackColor = SystemColors.Window;
                textBox3.BackColor = SystemColors.Window;
                textBox4.BackColor = SystemColors.Window;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                button1.Text = "Έλεγχος";
            }
        }

        private void help_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "online_help.chm", HelpNavigator.TopicId, "35");
        }
    }
}
