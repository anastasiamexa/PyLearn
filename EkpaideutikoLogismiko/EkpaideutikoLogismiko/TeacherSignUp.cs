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
    public partial class TeacherSignUp : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);

        public TeacherSignUp()
        {
            InitializeComponent();
        }

        // Make the form movable
        private void TeacherSignUp_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void TeacherSignUp_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void TeacherSignUp_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        // Key shortcuts
        private void TeacherSignUp_KeyDown(object sender, KeyEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(firstname.Text) || string.IsNullOrEmpty(lastname.Text) || string.IsNullOrEmpty(username.Text) || string.IsNullOrEmpty(password.Text))
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα πεδία", "Αποτυχία", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                // Check regex 
                string notification1 = Auxiliary.CheckRegex(firstname.Text.ToString(), lastname.Text.ToString(), username.Text.ToString(), password.Text.ToString());
                if (notification1 != null)
                    MessageBox.Show(notification1, "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    // Check database for duplicates (email, username)
                    string notification = Auxiliary.CheckForDublicates(username.Text.ToString());
                    if (notification != null)
                        MessageBox.Show(notification, "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        // Create salt
                        string salt = Convert.ToBase64String(Auxiliary.GenerateSalt());
                        // Hash password
                        string hashed_password = Auxiliary.HashPassword(password.Text.ToString(), Convert.FromBase64String(salt));
                        // Create user object
                        User user = new User(firstname.Text.ToString(), lastname.Text.ToString(), username.Text.ToString(), hashed_password, salt, true);
                        string s = user.StoreTeacherInfoToDB();
                        if (s == "done")
                        {
                            MessageBox.Show("Δημιουργήθηκε ο λογαριασμός", "Επιτυχία", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MainTeacherMenu form = new MainTeacherMenu();
                            form.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show(s, "Αποτυχία", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            TeacherLogin form = new TeacherLogin();
            form.Show();
            this.Hide();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Welcome form = new Welcome();
            form.Show();
            this.Hide();
        }

        private void help_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "online_help.chm", HelpNavigator.TopicId, "25");
        }
    }
}
