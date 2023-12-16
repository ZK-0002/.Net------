namespace _05
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
            lstCrawledUrls = new ListBox();
            txtKeyword = new TextBox();
            btnSearch = new Button();
            SuspendLayout();
            // 
            // lstCrawledUrls
            // 
            lstCrawledUrls.FormattingEnabled = true;
            lstCrawledUrls.Location = new Point(24, 104);
            lstCrawledUrls.Name = "lstCrawledUrls";
            lstCrawledUrls.Size = new Size(753, 304);
            lstCrawledUrls.TabIndex = 0;
            // 
            // txtKeyword
            // 
            txtKeyword.Location = new Point(70, 38);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.Size = new Size(194, 27);
            txtKeyword.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(418, 38);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(136, 30);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "start";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSearch);
            Controls.Add(txtKeyword);
            Controls.Add(lstCrawledUrls);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstCrawledUrls;
        private TextBox txtKeyword;
        private Button btnSearch;
    }
}
