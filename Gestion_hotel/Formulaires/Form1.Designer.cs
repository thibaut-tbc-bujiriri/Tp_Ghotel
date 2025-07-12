namespace Gestion_hotel
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            btnClient = new Guna.UI2.WinForms.Guna2Button();
            ptBox = new PictureBox();
            button1 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ptBox).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btnClient);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(259, 788);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.TBC_P__11_;
            pictureBox1.Location = new Point(0, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(113, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // btnClient
            // 
            btnClient.Cursor = Cursors.Hand;
            btnClient.CustomizableEdges = customizableEdges1;
            btnClient.DisabledState.BorderColor = Color.DarkGray;
            btnClient.DisabledState.CustomBorderColor = Color.DarkGray;
            btnClient.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnClient.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnClient.FillColor = Color.Black;
            btnClient.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClient.ForeColor = Color.White;
            btnClient.Location = new Point(111, 29);
            btnClient.Name = "btnClient";
            btnClient.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnClient.Size = new Size(146, 50);
            btnClient.TabIndex = 2;
            btnClient.Text = "CLIENT";
            btnClient.Click += btnClient_Click;
            // 
            // ptBox
            // 
            ptBox.Image = Properties.Resources.sac;
            ptBox.Location = new Point(399, 130);
            ptBox.Name = "ptBox";
            ptBox.Size = new Size(819, 530);
            ptBox.SizeMode = PictureBoxSizeMode.Zoom;
            ptBox.TabIndex = 0;
            ptBox.TabStop = false;
            ptBox.Click += ptBox_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaptionText;
            button1.Cursor = Cursors.Hand;
            button1.ForeColor = Color.White;
            button1.Location = new Point(1318, -3);
            button1.Name = "button1";
            button1.Size = new Size(50, 31);
            button1.TabIndex = 2;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1365, 788);
            Controls.Add(button1);
            Controls.Add(ptBox);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DashBoard";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ptBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox ptBox;
        private Guna.UI2.WinForms.Guna2Button btnClient;
        private PictureBox pictureBox1;
        private Button button1;
    }
}
