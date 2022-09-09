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
    public partial class TeacherLogin : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);

        public TeacherLogin()
        {
            InitializeComponent();
        }

        // Make the form movable
        private void TeacherLogin_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void TeacherLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void TeacherLogin_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        // Key shortcuts
        private void TeacherLogin_KeyDown(object sender, KeyEventArgs e)
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

        // Open sign up
        private void label4_Click(object sender, EventArgs e)
        {
            TeacherSignUp form = new TeacherSignUp();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Check if user's input is valid
            string notification = Auxiliary.IsValidUserInputLogIn(username.Text.ToString().Trim(), password.Text.ToString().Trim());
            if (notification != null)
            {
                MessageBox.Show(notification, "Αποτυχία", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                User user = new User(username.Text.Trim());
                //Check if user's credentials match a dababase record
                notification = user.AuthenticateTeacherCredentials(password.Text.ToString().Trim());
                if (notification != null)
                {
                    MessageBox.Show(notification, "Αποτυχία", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    //MessageBox.Show("Επιτυχής σύνδεση σε λογαριασμό", "Επιτυχία", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MainTeacherMenu form = new MainTeacherMenu();
                    form.Show();
                    this.Hide();
                }
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            Welcome form = new Welcome();
            form.Show();
            this.Hide();
        }

        private void help_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "online_help.chm", HelpNavigator.TopicId, "15");
        }
    }
}
