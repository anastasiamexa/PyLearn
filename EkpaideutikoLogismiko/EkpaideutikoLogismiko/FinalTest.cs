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
    public partial class FinalTest : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);
        List<Object> questions = new List<Object>(); // List containing multiple choice and true false questions
        List<object> rquestions; // The same list as before but now its contents are shuffled
        List<int> qids = new List<int>(); // List containing the ids of the questions
        List<string> answers = new List<string>(); // List containing the user's answers
        List<string> rightAnswers = new List<string>(); // List containing the right answers
        string flag = ""; // Variable showing the type of question
        int i = 1;
        int gaps;
        //bool isCheck = true;
        string username = "";

        public FinalTest()
        {
            InitializeComponent();
        }

        public FinalTest(string u)
        {
            InitializeComponent();
            username = u;
            panel1.Visible = false;
            panel2.Visible = false;

            // Generate random number questions
            // The total number of questions is always 12
            Random rnd = new Random();

            // Retrieve the multiple choice questions from database
            string query = "select * from multiplechoice";
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
            string query2 = "select * from truefalse";
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

            // Retrieve the fillgap questions from database
            string query3 = "select * from fillgap";
            List<FillGap> fillGapList = new List<FillGap>(); // List containing all of the fillgap questions
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(Auxiliary.CONNECTION_STRING);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query3, connection);
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
            string query4 = "select * from sequence";
            List<Sequence> sequenceList = new List<Sequence>(); // List containing all of the sequence questions
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(Auxiliary.CONNECTION_STRING);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query4, connection);
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

            // Shuffle lists and take the first 3 random elements of each list
            var rmultipleChoiseList = multipleChoiseList.OrderBy(item => rnd.Next()).Take(3);
            var rtrueFalseList = trueFalseList.OrderBy(item => rnd.Next()).Take(3);
            var rfillGapList = fillGapList.OrderBy(item => rnd.Next()).Take(3);
            var rsequenceList = sequenceList.OrderBy(item => rnd.Next()).Take(3);

            System.Diagnostics.Debug.WriteLine(rmultipleChoiseList.Count());
            System.Diagnostics.Debug.WriteLine(rtrueFalseList.Count());
            System.Diagnostics.Debug.WriteLine(rfillGapList.Count());
            System.Diagnostics.Debug.WriteLine(rsequenceList.Count());
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
            if (o.GetType().ToString().Equals("EkpaideutikoLogismiko.TrueFalse"))
            {
                panel1.Visible = true;
                panel2.Visible = false;
                flag = "truefalse";
                System.Diagnostics.Debug.WriteLine(o.GetType().ToString() + " ------------" + ((TrueFalse)o).id);
                question.Text = ((TrueFalse)o).question;
                firste.Text = "Σωστό";
                seconde.Text = "Λάθος";
                thirde.Text = "";
                fourthe.Text = "";
                thirde.Visible = false;
                fourthe.Visible = false;
                qids.Add(((TrueFalse)o).id);
                rightAnswers.Add(((TrueFalse)o).answer.ToString());
            }
            else if (o.GetType().ToString().Equals("EkpaideutikoLogismiko.MultipleChoice"))
            {
                panel1.Visible = true;
                panel2.Visible = false;
                flag = "multiple";
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
                firste.Text = ((MultipleChoice)o).first;
                seconde.Text = ((MultipleChoice)o).second;
                if (String.IsNullOrEmpty(((MultipleChoice)o).third))
                {
                    thirde.Visible = false;
                }
                else
                {
                    thirde.Text = ((MultipleChoice)o).third;

                }
                if (String.IsNullOrEmpty(((MultipleChoice)o).fourth))
                {
                    fourthe.Visible = false;
                }
                else
                {
                    fourthe.Text = ((MultipleChoice)o).fourth;
                }
                qids.Add(((MultipleChoice)o).id);
                rightAnswers.Add(((MultipleChoice)o).answer.ToString());
            }
            else if (o.GetType().ToString().Equals("EkpaideutikoLogismiko.Sequence"))
            {
                panel1.Visible = false;
                panel2.Visible = true;
                firsth.Visible = true;
                secondh.Visible = true;
                thirdh.Visible = true;
                fourthh.Visible = true;
                fifthh.Visible = true;
                sixthh.Visible = true;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                flag = "sequence";
                System.Diagnostics.Debug.WriteLine(o.GetType().ToString() + " ------------" + ((Sequence)o).id);
                question.Text = ((Sequence)o).question;
                firsth.Text = "1: " + ((Sequence)o).first;
                secondh.Text = "2: " + ((Sequence)o).second;
                thirdh.Text = "3: " + ((Sequence)o).third;
                if (String.IsNullOrEmpty(((Sequence)o).fourth))
                {
                    fourthh.Visible = false;
                }
                else
                {
                    fourthh.Visible = true;
                    fourthh.Text = "4: " + ((Sequence)o).fourth;
                }
                if (String.IsNullOrEmpty(((Sequence)o).fifth))
                {
                    fifthh.Visible = false;
                }
                else
                {
                    fifthh.Visible = true;
                    fifthh.Text = "5: " + ((Sequence)o).fifth;
                }
                if (String.IsNullOrEmpty(((Sequence)o).sixth))
                {
                    sixthh.Visible = false;
                }
                else
                {
                    sixthh.Visible = true;
                    sixthh.Text = "6: " + ((Sequence)o).sixth;
                }
                qids.Add(((Sequence)o).id);
                rightAnswers.Add(((Sequence)o).answer.ToString());
            }
            else if (o.GetType().ToString().Equals("EkpaideutikoLogismiko.FillGap"))
            {
                panel1.Visible = false;
                panel2.Visible = true;
                firsth.Visible = false;
                secondh.Visible = false;
                thirdh.Visible = false;
                fourthh.Visible = false;
                fifthh.Visible = false;
                sixthh.Visible = false;
                flag = "fillgap";
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
        }

        // Next question button
        private void button1_Click(object sender, EventArgs e)
        {
            // Get user's answer
            if (flag.Equals("truefalse"))
            {
                if (firste.Checked == true)
                {
                    answers.Add("True");
                }
                if (seconde.Checked == true)
                {
                    answers.Add("False");
                }
            }
            else if (flag.Equals("multiple"))
            {
                if (firste.Checked == true)
                {
                    answers.Add("1");
                }
                if (seconde.Checked == true)
                {
                    answers.Add("2");
                }
                if (thirde.Checked == true)
                {
                    answers.Add("3");
                }
                if (fourthe.Checked == true)
                {
                    answers.Add("4");
                }
            }
            else if (flag.Equals("fillgap"))
            {
                string message = "";
                string answer = "";
                // Get user's input
                if (String.IsNullOrEmpty(textBox1.Text.ToString()) && textBox1.Visible == true)
                {
                    message = message + " 1";
                }
                else if (textBox1.Visible == true)
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
            }
            else if (flag.Equals("sequence"))
            {
                if (String.IsNullOrEmpty(textBox1.Text.ToString()))
                {
                    MessageBox.Show("Συμπλήρωσε κείμενο στο πεδίο", "Αποτυχία", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    answers.Add(textBox1.Text.ToString());
                }
            }

            if (i == 12) // User answered all the questions go back to main menu
            {
                // Calculate the results
                int score = 0;
                List<bool> scores = new List<bool>();
                for (int i = 0; i < 12; i++)
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
                string query = "insert into testhistory values (@username, @date_time, @id1, @id2, @id3, @id4, @id5, @id6, @id7, @id8, @id9, @id10, @id11, @id12, " +
                    "@answer1, @answer2, @answer3, @answer4, @answer5, @answer6, @answer7, @answer8, @answer9, @answer10, @answer11, @answer12)";
                try
                {
                    NpgsqlConnection connection = new NpgsqlConnection(Auxiliary.CONNECTION_STRING);
                    connection.Open();
                    //define query's parameters
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    command.Parameters.AddWithValue("username", username);
                    command.Parameters.AddWithValue("date_time", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
                    command.Parameters.AddWithValue("id1", qids.ElementAt(0));
                    command.Parameters.AddWithValue("id2", qids.ElementAt(1));
                    command.Parameters.AddWithValue("id3", qids.ElementAt(2));
                    command.Parameters.AddWithValue("id4", qids.ElementAt(3));
                    command.Parameters.AddWithValue("id5", qids.ElementAt(4));
                    command.Parameters.AddWithValue("id6", qids.ElementAt(5));
                    command.Parameters.AddWithValue("id7", qids.ElementAt(6));
                    command.Parameters.AddWithValue("id8", qids.ElementAt(7));
                    command.Parameters.AddWithValue("id9", qids.ElementAt(8));
                    command.Parameters.AddWithValue("id10", qids.ElementAt(9));
                    command.Parameters.AddWithValue("id11", qids.ElementAt(10));
                    command.Parameters.AddWithValue("id12", qids.ElementAt(11));
                    command.Parameters.AddWithValue("answer1", scores.ElementAt(0));
                    command.Parameters.AddWithValue("answer2", scores.ElementAt(1));
                    command.Parameters.AddWithValue("answer3", scores.ElementAt(2));
                    command.Parameters.AddWithValue("answer4", scores.ElementAt(3));
                    command.Parameters.AddWithValue("answer5", scores.ElementAt(4));
                    command.Parameters.AddWithValue("answer6", scores.ElementAt(5));
                    command.Parameters.AddWithValue("answer7", scores.ElementAt(6));
                    command.Parameters.AddWithValue("answer8", scores.ElementAt(7));
                    command.Parameters.AddWithValue("answer9", scores.ElementAt(8));
                    command.Parameters.AddWithValue("answer10", scores.ElementAt(9));
                    command.Parameters.AddWithValue("answer11", scores.ElementAt(10));
                    command.Parameters.AddWithValue("answer12", scores.ElementAt(11));
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
                System.Diagnostics.Debug.WriteLine(username + "'s score: " + score.ToString() + "/12");
            }
            else
            {
                questionNumber.Text = "Ερώτηση " + (i + 1);
                // Take the next question
                object o = new object();
                o = rquestions.ElementAt(i);
                thirde.Visible = true;
                fourthe.Visible = true;
                // Check the question's type
                if (o.GetType().ToString().Equals("EkpaideutikoLogismiko.TrueFalse"))
                {
                    System.Diagnostics.Debug.WriteLine(o.GetType().ToString() + " ------------" + ((TrueFalse)o).id);
                    panel1.Visible = true;
                    panel2.Visible = false;
                    flag = "truefalse";
                    question.Text = ((TrueFalse)o).question;
                    firste.Text = "Σωστό";
                    seconde.Text = "Λάθος";
                    thirde.Visible = false;
                    thirde.Text = "";
                    fourthe.Visible = false;
                    fourthe.Text = "";
                    qids.Add(((TrueFalse)o).id);
                    rightAnswers.Add(((TrueFalse)o).answer.ToString());
                    //System.Diagnostics.Debug.WriteLine(((TrueFalse)Convert.ChangeType(rquestions.ElementAt(0), typeof(TrueFalse))).id);
                    //System.Diagnostics.Debug.WriteLine(((MultipleChoice)Convert.ChangeType(rquestions.ElementAt(0), typeof(MultipleChoice))).id);
                }
                else if (o.GetType().ToString().Equals("EkpaideutikoLogismiko.MultipleChoice"))
                {
                    System.Diagnostics.Debug.WriteLine(o.GetType().ToString() + " ------------" + ((MultipleChoice)o).id);
                    panel1.Visible = true;
                    panel2.Visible = false;
                    flag = "multiple";
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
                    firste.Text = ((MultipleChoice)o).first;
                    seconde.Text = ((MultipleChoice)o).second;
                    if (String.IsNullOrEmpty(((MultipleChoice)o).third))
                    {
                        thirde.Visible = false;
                        thirde.Text = "";
                    }
                    else
                    {
                        thirde.Text = ((MultipleChoice)o).third;

                    }
                    if (String.IsNullOrEmpty(((MultipleChoice)o).fourth))
                    {
                        fourthe.Visible = false;
                        fourthe.Text = "";
                    }
                    else
                    {
                        fourthe.Text = ((MultipleChoice)o).fourth;
                    }
                    qids.Add(((MultipleChoice)o).id);
                    rightAnswers.Add(((MultipleChoice)o).answer.ToString());
                }
                else if (o.GetType().ToString().Equals("EkpaideutikoLogismiko.Sequence"))
                {
                    panel1.Visible = false;
                    panel2.Visible = true;
                    firsth.Visible = true;
                    secondh.Visible = true;
                    thirdh.Visible = true;
                    fourthh.Visible = true;
                    fifthh.Visible = true;
                    sixthh.Visible = true;

                    label2.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    textBox2.Visible = false;
                    textBox3.Visible = false;
                    textBox4.Visible = false;
                    System.Diagnostics.Debug.WriteLine(o.GetType().ToString() + " ------------" + ((Sequence)o).id);
                    flag = "sequence";
                    question.Text = ((Sequence)o).question;
                    firsth.Text = "1: " + ((Sequence)o).first;
                    secondh.Text = "2: " + ((Sequence)o).second;
                    thirdh.Text = "3: " + ((Sequence)o).third;
                    if (String.IsNullOrEmpty(((Sequence)o).fourth))
                    {
                        fourthh.Visible = false;
                    }
                    else
                    {
                        fourthh.Visible = true;
                        fourthh.Text = "4: " + ((Sequence)o).fourth;
                    }
                    if (String.IsNullOrEmpty(((Sequence)o).fifth))
                    {
                        fifthh.Visible = false;
                    }
                    else
                    {
                        fifthh.Visible = true;
                        fifthh.Text = "5: " + ((Sequence)o).fifth;
                    }
                    if (String.IsNullOrEmpty(((Sequence)o).sixth))
                    {
                        sixthh.Visible = false;
                    }
                    else
                    {
                        sixthh.Visible = true;
                        sixthh.Text = "6: " + ((Sequence)o).sixth;
                    }
                    qids.Add(((Sequence)o).id);
                    rightAnswers.Add(((Sequence)o).answer.ToString());
                }
                else if (o.GetType().ToString().Equals("EkpaideutikoLogismiko.FillGap"))
                {
                    panel1.Visible = false;
                    panel2.Visible = true;
                    firsth.Visible = false;
                    secondh.Visible = false;
                    thirdh.Visible = false;
                    fourthh.Visible = false;
                    fifthh.Visible = false;
                    sixthh.Visible = false;
                    System.Diagnostics.Debug.WriteLine(o.GetType().ToString() + " ------------" + ((FillGap)o).id);
                    flag = "fillgap";
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
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                if (i == 11)
                {
                    button1.Text = "Υποβολή";
                }
                i++;
            }
        }

        // Make the form movable
        private void FinalTest_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void FinalTest_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void FinalTest_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        // Key shortcuts
        private void FinalTest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.E)
            {
                exit.PerformClick();
            }

            if (e.Control == true && e.KeyCode == Keys.H)
            {
                help.PerformClick();
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

        private void back_Click(object sender, EventArgs e)
        {
            MainStudentMenu form = new MainStudentMenu(username);
            form.Show();
            this.Hide();
        }

        private void back_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Πίσω (Ctrl + B)", back);
        }

        private void help_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "online_help.chm", HelpNavigator.TopicId, "37");
        }
    }
}
