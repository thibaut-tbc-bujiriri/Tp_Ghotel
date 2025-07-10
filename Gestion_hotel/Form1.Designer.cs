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
            panel1 = new Panel();
            ptBox = new PictureBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)ptBox).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(259, 565);
            panel1.TabIndex = 0;
            // 
            // ptBox
            // 
            ptBox.Image = Properties.Resources.sac;
            ptBox.Location = new Point(465, 130);
            ptBox.Name = "ptBox";
            ptBox.Size = new Size(434, 347);
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
            button1.Location = new Point(991, -3);
            button1.Name = "button1";
            button1.Size = new Size(50, 31);
            button1.TabIndex = 1;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1038, 565);
            Controls.Add(button1);
            Controls.Add(ptBox);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DashBoard";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)ptBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox ptBox;
        private Button button1;
    }
}
