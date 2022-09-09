namespace EkpaideutikoLogismiko
{
    partial class TeacherLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.help = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // username
            // 
            this.username.Font = new System.Drawing.Font("Century Gothic", 21F);
            this.username.Location = new System.Drawing.Point(416, 206);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(487, 42);
            this.username.TabIndex = 0;
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Century Gothic", 21F);
            this.password.Location = new System.Drawing.Point(415, 320);
            this.password.Name = "password";
            this.password.PasswordChar = '●';
            this.password.Size = new System.Drawing.Size(488, 42);
            this.password.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 28F);
            this.label3.Location = new System.Drawing.Point(385, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(572, 45);
            this.label3.TabIndex = 6;
            this.label3.Text = "Είσοδος στο λογαριασμό σας";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20F);
            this.label1.Location = new System.Drawing.Point(408, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 33);
            this.label1.TabIndex = 7;
            this.label1.Text = "Όνομα χρήστη";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 20F);
            this.label2.Location = new System.Drawing.Point(411, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 33);
            this.label2.TabIndex = 8;
            this.label2.Text = "Κωδικός";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSlateGray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 20F);
            this.button1.Location = new System.Drawing.Point(553, 446);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 63);
            this.button1.TabIndex = 9;
            this.button1.TabStop = false;
            this.button1.Text = "Σύνδεση";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.label4.Location = new System.Drawing.Point(447, 385);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(426, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Δεν έχετε λογαριασμό; Δημιουργείστε έναν.";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // help
            // 
            this.help.BackColor = System.Drawing.Color.Transparent;
            this.help.BackgroundImage = global::EkpaideutikoLogismiko.Properties.Resources.baseline_help_black_48dp;
            this.help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.help.Cursor = System.Windows.Forms.Cursors.Hand;
            this.help.FlatAppearance.BorderSize = 0;
            this.help.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.help.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.help.Location = new System.Drawing.Point(1160, 8);
            this.help.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(63, 62);
            this.help.TabIndex = 26;
            this.help.TabStop = false;
            this.help.UseVisualStyleBackColor = false;
            this.help.Click += new System.EventHandler(this.help_Click);
            this.help.MouseHover += new System.EventHandler(this.help_MouseHover);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Transparent;
            this.exit.BackgroundImage = global::EkpaideutikoLogismiko.Properties.Resources.baseline_cancel_black_48dp;
            this.exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit.FlatAppearance.BorderSize = 0;
            this.exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Location = new System.Drawing.Point(1227, 8);
            this.exit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(63, 62);
            this.exit.TabIndex = 25;
            this.exit.TabStop = false;
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            this.exit.MouseHover += new System.EventHandler(this.exit_MouseHover);
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.Transparent;
            this.back.BackgroundImage = global::EkpaideutikoLogismiko.Properties.Resources.baseline_west_black_48dp;
            this.back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.back.FlatAppearance.BorderSize = 0;
            this.back.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.back.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back.Location = new System.Drawing.Point(8, 8);
            this.back.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(63, 62);
            this.back.TabIndex = 40;
            this.back.TabStop = false;
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            this.back.MouseHover += new System.EventHandler(this.back_MouseHover);
            // 
            // TeacherLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1297, 715);
            this.Controls.Add(this.back);
            this.Controls.Add(this.help);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TeacherLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TeacherLogin";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TeacherLogin_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TeacherLogin_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TeacherLogin_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TeacherLogin_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button help;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button back;
    }
}