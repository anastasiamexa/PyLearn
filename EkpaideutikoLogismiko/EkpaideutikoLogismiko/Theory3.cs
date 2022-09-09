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
    public partial class Theory3 : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);
        string username = "";

        public Theory3(string u)
        {
            InitializeComponent();
            username = u;
        }

        // Make the form movable
        private void Theory3_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Theory3_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void Theory3_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        // Key shortcuts
        private void Theory3_KeyDown(object sender, KeyEventArgs e)
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

        // Next button
        private void button1_Click(object sender, EventArgs e)
        {
            Theory2 form = new Theory2(username);
            form.Show();
            this.Hide();
        }

        private void help_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "online_help.chm", HelpNavigator.TopicId, "32");
        }
    }
}
