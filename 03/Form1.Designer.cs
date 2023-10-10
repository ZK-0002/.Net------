namespace Statistics
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
            button1 = new Button();
            listBox1 = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(166, 59);
            button1.Name = "button1";
            button1.Size = new Size(114, 41);
            button1.TabIndex = 0;
            button1.Text = "Select File";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(479, 49);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(374, 424);
            listBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(292, 157);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(292, 234);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(292, 302);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(292, 375);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(114, 157);
            label5.Name = "label5";
            label5.Size = new Size(152, 20);
            label5.TabIndex = 6;
            label5.Text = "Original Line Count:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(114, 234);
            label6.Name = "label6";
            label6.Size = new Size(163, 20);
            label6.TabIndex = 7;
            label6.Text = "Original Word Count:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(114, 302);
            label7.Name = "label7";
            label7.Size = new Size(172, 20);
            label7.TabIndex = 8;
            label7.Text = "Formatted Line Count:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(114, 375);
            label8.Name = "label8";
            label8.Size = new Size(183, 20);
            label8.TabIndex = 9;
            label8.Text = "Formatted Word Count:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(940, 514);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ListBox listBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}