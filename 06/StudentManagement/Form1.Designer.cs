namespace StudentManagement
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.schoolComboBox = new System.Windows.Forms.ComboBox();
            this.classListBox = new System.Windows.Forms.ListBox();
            this.studentsDataGridView = new System.Windows.Forms.DataGridView();
            this.schoolNameTextBox = new System.Windows.Forms.TextBox();
            this.classNameTextBox = new System.Windows.Forms.TextBox();
            this.studentNameTextBox = new System.Windows.Forms.TextBox();
            this.addSchoolButton = new System.Windows.Forms.Button();
            this.addClassButton = new System.Windows.Forms.Button();
            this.addStudentButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.studentsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // schoolComboBox
            // 
            this.schoolComboBox.FormattingEnabled = true;
            this.schoolComboBox.Location = new System.Drawing.Point(95, 44);
            this.schoolComboBox.Name = "schoolComboBox";
            this.schoolComboBox.Size = new System.Drawing.Size(182, 23);
            this.schoolComboBox.TabIndex = 0;
            // 
            // classListBox
            // 
            this.classListBox.FormattingEnabled = true;
            this.classListBox.ItemHeight = 15;
            this.classListBox.Location = new System.Drawing.Point(95, 141);
            this.classListBox.Name = "classListBox";
            this.classListBox.Size = new System.Drawing.Size(198, 229);
            this.classListBox.TabIndex = 1;
            // 
            // studentsDataGridView
            // 
            this.studentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studentsDataGridView.Location = new System.Drawing.Point(333, 144);
            this.studentsDataGridView.Name = "studentsDataGridView";
            this.studentsDataGridView.RowHeadersWidth = 51;
            this.studentsDataGridView.RowTemplate.Height = 27;
            this.studentsDataGridView.Size = new System.Drawing.Size(312, 225);
            this.studentsDataGridView.TabIndex = 2;
            // 
            // schoolNameTextBox
            // 
            this.schoolNameTextBox.Location = new System.Drawing.Point(328, 41);
            this.schoolNameTextBox.Name = "schoolNameTextBox";
            this.schoolNameTextBox.Size = new System.Drawing.Size(126, 25);
            this.schoolNameTextBox.TabIndex = 3;
            // 
            // classNameTextBox
            // 
            this.classNameTextBox.Location = new System.Drawing.Point(487, 42);
            this.classNameTextBox.Name = "classNameTextBox";
            this.classNameTextBox.Size = new System.Drawing.Size(132, 25);
            this.classNameTextBox.TabIndex = 4;
            // 
            // studentNameTextBox
            // 
            this.studentNameTextBox.Location = new System.Drawing.Point(650, 42);
            this.studentNameTextBox.Name = "studentNameTextBox";
            this.studentNameTextBox.Size = new System.Drawing.Size(127, 25);
            this.studentNameTextBox.TabIndex = 5;
            // 
            // addSchoolButton
            // 
            this.addSchoolButton.Location = new System.Drawing.Point(330, 94);
            this.addSchoolButton.Name = "addSchoolButton";
            this.addSchoolButton.Size = new System.Drawing.Size(123, 31);
            this.addSchoolButton.TabIndex = 6;
            this.addSchoolButton.Text = "addSchool";
            this.addSchoolButton.UseVisualStyleBackColor = true;
            // 
            // addClassButton
            // 
            this.addClassButton.Location = new System.Drawing.Point(488, 96);
            this.addClassButton.Name = "addClassButton";
            this.addClassButton.Size = new System.Drawing.Size(130, 28);
            this.addClassButton.TabIndex = 7;
            this.addClassButton.Text = "addClass";
            this.addClassButton.UseVisualStyleBackColor = true;
            // 
            // addStudentButton
            // 
            this.addStudentButton.Location = new System.Drawing.Point(653, 98);
            this.addStudentButton.Name = "addStudentButton";
            this.addStudentButton.Size = new System.Drawing.Size(123, 26);
            this.addStudentButton.TabIndex = 8;
            this.addStudentButton.Text = "addStudent";
            this.addStudentButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.addStudentButton);
            this.Controls.Add(this.addClassButton);
            this.Controls.Add(this.addSchoolButton);
            this.Controls.Add(this.studentNameTextBox);
            this.Controls.Add(this.classNameTextBox);
            this.Controls.Add(this.schoolNameTextBox);
            this.Controls.Add(this.studentsDataGridView);
            this.Controls.Add(this.classListBox);
            this.Controls.Add(this.schoolComboBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.studentsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox schoolComboBox;
        private System.Windows.Forms.ListBox classListBox;
        private System.Windows.Forms.DataGridView studentsDataGridView;
        private System.Windows.Forms.TextBox schoolNameTextBox;
        private System.Windows.Forms.TextBox classNameTextBox;
        private System.Windows.Forms.TextBox studentNameTextBox;
        private System.Windows.Forms.Button addSchoolButton;
        private System.Windows.Forms.Button addClassButton;
        private System.Windows.Forms.Button addStudentButton;
    }
}

