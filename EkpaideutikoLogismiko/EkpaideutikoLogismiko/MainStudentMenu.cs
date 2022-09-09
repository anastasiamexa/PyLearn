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
    public partial class MainStudentMenu : Form
    {
        private bool _dragging = false, showFinalTest = true;
        private Point _start_point = new Point(0, 0);
        string username = "";

        public MainStudentMenu()
        {
            InitializeComponent();
        }

        public MainStudentMenu(string u)
        {
            InitializeComponent();
            username = u;
            picture1.Visible = false;
            picture2.Visible = false;
            picture3.Visible = false;
            label9.Visible = false;

            // Chapter 1 easy test
            int score = 0;
            bool hasHistory = false;
            string query = "select answer1, answer2, answer3, answer4, answer5 from exercisehistory where username = '" + username + "' and chapter = 1 and difficulty = 0 ";
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(Auxiliary.CONNECTION_STRING);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataReader dataReader = command.ExecuteReader(); // Run query                    

                while (dataReader.Read())
                {
                    hasHistory = true;
                    for (int i = 0; i < 5; i++)
                    {
                        //System.Diagnostics.Debug.WriteLine(dataReader[i].ToString());
                        if (dataReader[i].ToString() == "True")
                        {
                            score++;
                        }
                    }
                }
                connection.Close();

                if (hasHistory)
                {
                    if (score < 3)
                    {
                        picture1easy.BackgroundImage = Properties.Resources.failed;
                    }
                    else if (score == 3)
                    {
                        picture1easy.BackgroundImage = Properties.Resources.bronze_medal;
                    }
                    else if (score == 4)
                    {
                        picture1easy.BackgroundImage = Properties.Resources.silver_medal;
                    }
                    else if (score == 5)
                    {
                        picture1easy.BackgroundImage = Properties.Resources.gold_medal;
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Κάτι πήγε λάθος", "Αποτυχία", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Chapter 2 easy test
            int score2 = 0;
            bool hasHistory2 = false;
            string query2 = "select answer1, answer2, answer3, answer4, answer5 from exercisehistory where username = '" + username + "' and chapter = 2 and difficulty = 0 ";
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(Auxiliary.CONNECTION_STRING);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query2, connection);
                NpgsqlDataReader dataReader = command.ExecuteReader(); // Run query                    

                while (dataReader.Read())
                {
                    hasHistory2 = true;
                    for (int i = 0; i < 5; i++)
                    {
                        //System.Diagnostics.Debug.WriteLine(dataReader[i].ToString());
                        if (dataReader[i].ToString() == "True")
                        {
                            score2++;
                        }
                    }
                }
                connection.Close();

                if (hasHistory2)
                {
                    if (score2 < 3)
                    {
                        picture2easy.BackgroundImage = Properties.Resources.failed;
                    }
                    else if (score2 == 3)
                    {
                        picture2easy.BackgroundImage = Properties.Resources.bronze_medal;
                    }
                    else if (score2 == 4)
                    {
                        picture2easy.BackgroundImage = Properties.Resources.silver_medal;
                    }
                    else if (score2 == 5)
                    {
                        picture2easy.BackgroundImage = Properties.Resources.gold_medal;
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Κάτι πήγε λάθος", "Αποτυχία", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Chapter 1 hard test
            int score3 = 0;
            bool hasHistory3 = false;
            string query3 = "select answer1, answer2, answer3, answer4, answer5 from exercisehistory where username = '" + username + "' and chapter = 1 and difficulty = 1 ";
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(Auxiliary.CONNECTION_STRING);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query3, connection);
                NpgsqlDataReader dataReader = command.ExecuteReader(); // Run query                    

                while (dataReader.Read())
                {
                    hasHistory3 = true;
                    for (int i = 0; i < 5; i++)
                    {
                        //System.Diagnostics.Debug.WriteLine(dataReader[i].ToString());
                        if (dataReader[i].ToString() == "True")
                        {
                            score3++;
                        }
                    }
                }
                connection.Close();

                if (hasHistory3)
                {
                    if (score3 < 3)
                    {
                        picture1hard.BackgroundImage = Properties.Resources.failed;
                    }
                    else if (score3 == 3)
                    {
                        picture1hard.BackgroundImage = Properties.Resources.bronze_medal;
                    }
                    else if (score3 == 4)
                    {
                        picture1hard.BackgroundImage = Properties.Resources.silver_medal;
                    }
                    else if (score3 == 5)
                    {
                        picture1hard.BackgroundImage = Properties.Resources.gold_medal;
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Κάτι πήγε λάθος", "Αποτυχία", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (score3 >= 3 && score >= 3)
            {
                picture1.Visible = true;
            }
            else
            {
                showFinalTest = false;
            }

            // Chapter 2 hard test
            int score4 = 0;
            bool hasHistory4 = false;
            string query4 = "select answer1, answer2, answer3, answer4, answer5 from exercisehistory where username = '" + username + "' and chapter = 2 and difficulty = 1 ";
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(Auxiliary.CONNECTION_STRING);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query4, connection);
                NpgsqlDataReader dataReader = command.ExecuteReader(); // Run query                    

                while (dataReader.Read())
                {
                    hasHistory4 = true;
                    for (int i = 0; i < 5; i++)
                    {
                        //System.Diagnostics.Debug.WriteLine(dataReader[i].ToString());
                        if (dataReader[i].ToString() == "True")
                        {
                            score4++;
                        }
                    }
                }
                connection.Close();

                if (hasHistory4)
                {
                    if (score4 < 3)
                    {
                        picture2hard.BackgroundImage = Properties.Resources.failed;
                    }
                    else if (score4 == 3)
                    {
                        picture2hard.BackgroundImage = Properties.Resources.bronze_medal;
                    }
                    else if (score4 == 4)
                    {
                        picture2hard.BackgroundImage = Properties.Resources.silver_medal;
                    }
                    else if (score4 == 5)
                    {
                        picture2hard.BackgroundImage = Properties.Resources.gold_medal;
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Κάτι πήγε λάθος", "Αποτυχία", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (score4 >= 3 && score2 >= 3)
            {
                picture2.Visible = true;
            }
            else
            {
                showFinalTest = false;
            }

            // Chapter 3 easy test
            int score5 = 0;
            bool hasHistory5 = false;
            string query5 = "select answer1, answer2, answer3, answer4, answer5 from exercisehistory where username = '" + username + "' and chapter = 3 and difficulty = 0 ";
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(Auxiliary.CONNECTION_STRING);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query5, connection);
                NpgsqlDataReader dataReader = command.ExecuteReader(); // Run query                    

                while (dataReader.Read())
                {
                    hasHistory5 = true;
                    for (int i = 0; i < 5; i++)
                    {
                        //System.Diagnostics.Debug.WriteLine(dataReader[i].ToString());
                        if (dataReader[i].ToString() == "True")
                        {
                            score5++;
                        }
                    }
                }
                connection.Close();

                if (hasHistory5)
                {
                    if (score5 < 3)
                    {
                        picture3easy.BackgroundImage = Properties.Resources.failed;
                    }
                    else if (score5 == 3)
                    {
                        picture3easy.BackgroundImage = Properties.Resources.bronze_medal;
                    }
                    else if (score5 == 4)
                    {
                        picture3easy.BackgroundImage = Properties.Resources.silver_medal;
                    }
                    else if (score5 == 5)
                    {
                        picture3easy.BackgroundImage = Properties.Resources.gold_medal;
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Κάτι πήγε λάθος", "Αποτυχία", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Chapter 3 hard test
            int score6 = 0;
            bool hasHistory6 = false;
            string query6 = "select answer1, answer2, answer3, answer4, answer5 from exercisehistory where username = '" + username + "' and chapter = 3 and difficulty = 1 ";
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(Auxiliary.CONNECTION_STRING);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query6, connection);
                NpgsqlDataReader dataReader = command.ExecuteReader(); // Run query                    

                while (dataReader.Read())
                {
                    hasHistory6 = true;
                    for (int i = 0; i < 5; i++)
                    {
                        //System.Diagnostics.Debug.WriteLine(dataReader[i].ToString());
                        if (dataReader[i].ToString() == "True")
                        {
                            score6++;
                        }
                    }
                }
                connection.Close();

                if (hasHistory6)
                {
                    if (score6 < 3)
                    {
                        picture3hard.BackgroundImage = Properties.Resources.failed;
                    }
                    else if (score6 == 3)
                    {
                        picture3hard.BackgroundImage = Properties.Resources.bronze_medal;
                    }
                    else if (score6 == 4)
                    {
                        picture3hard.BackgroundImage = Properties.Resources.silver_medal;
                    }
                    else if (score6 == 5)
                    {
                        picture3hard.BackgroundImage = Properties.Resources.gold_medal;
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Κάτι πήγε λάθος", "Αποτυχία", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (score6 >= 3 && score5 >= 3)
            {
                picture3.Visible = true;

            }
            else
            {
                showFinalTest = false;
            }

            // Check if user has completed all the chapters, if so show the final test
            if (showFinalTest == true)
            {
                label9.Visible = true;
            }

            // If user has completed the final test
            int scoreFinal = 0;
            bool hasHistoryFinal = false;
            string queryFinal = "select answer1, answer2, answer3, answer4, answer5, answer6, answer7, answer8, answer9, answer10, answer11, answer12 from testhistory where username = '" + username + "'";
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(Auxiliary.CONNECTION_STRING);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(queryFinal, connection);
                NpgsqlDataReader dataReader = command.ExecuteReader(); // Run query                    

                while (dataReader.Read())
                {
                    hasHistoryFinal = true;
                    for (int i = 0; i < 12; i++)
                    {
                        //System.Diagnostics.Debug.WriteLine(dataReader[i].ToString());
                        if (dataReader[i].ToString() == "True")
                        {
                            scoreFinal++;
                        }
                    }
                }
                connection.Close();

                if (hasHistoryFinal)
                {
                    scoreLabel.Text = scoreFinal.ToString() + "/12";
                    scoreLabel.Visible = true;
                    label9.Visible = true;
                    label9.Enabled = false;
                    scoreLabel.Enabled = false;
                    label15.Visible = true;
                    label16.Visible = true;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Κάτι πήγε λάθος", "Αποτυχία", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

       


        // Make the form movable
        private void MainStudentMenu_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void MainStudentMenu_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void MainStudentMenu_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        // Key shortcuts
        private void MainStudentMenu_KeyDown(object sender, KeyEventArgs e)
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

        private void back_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Πίσω (Ctrl + B)", back);
        }

        // Chapter 1
        private void label3_Click(object sender, EventArgs e)
        {
            Theory1 form = new Theory1(username);
            form.Show();
            this.Hide();
        }

        private void chapter1easy_Click(object sender, EventArgs e)
        {
            EasyTest1 form = new EasyTest1(username);
            form.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Theory3 form = new Theory3(username);
            form.Show();
            this.Hide();
        }

        private void chapter2easy_Click(object sender, EventArgs e)
        {
            EasyTest2 form = new EasyTest2(username);
            form.Show();
            this.Hide();
        }

        private void chapter1hard_Click(object sender, EventArgs e)
        {
            HardTest1 form = new HardTest1(username);
            form.Show();
            this.Hide();
        }

        private void chapter2hard_Click(object sender, EventArgs e)
        {
            HardTest2 form = new HardTest2(username);
            form.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Theory5 form = new Theory5(username);
            form.Show();
            this.Hide();
        }

        private void chapter3easy_Click(object sender, EventArgs e)
        {
            EasyTest3 form = new EasyTest3(username);
            form.Show();
            this.Hide();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Welcome form = new Welcome();
            form.Show();
            this.Hide();
        }

        private void chapter3hard_Click(object sender, EventArgs e)
        {
            HardTest3 form = new HardTest3(username);
            form.Show();
            this.Hide();
        }

        private void help_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "online_help.chm", HelpNavigator.TopicId, "30");
        }

        private void label9_Click(object sender, EventArgs e)
        {
            FinalTest form = new FinalTest(username);
            form.Show();
            this.Hide();
        }
    }
}
