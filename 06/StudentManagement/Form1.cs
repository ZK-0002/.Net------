using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
            schoolComboBox.SelectedIndexChanged += schoolComboBox_SelectedIndexChanged;
            classListBox.SelectedIndexChanged += classListBox_SelectedIndexChanged;
            addSchoolButton.Click += addSchoolButton_Click;
            addClassButton.Click += addClassButton_Click;
            addStudentButton.Click += addStudentButton_Click;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // 加载学校列表
            LoadSchools();
        }

        private void LoadSchools()
        {
            // 查询学校列表
            string query = "SELECT * FROM School";
            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

            // 将学校数据绑定到ComboBox
            schoolComboBox.DataSource = dataTable;
            schoolComboBox.DisplayMember = "SchoolName";
            schoolComboBox.ValueMember = "SchoolId";
        }

        private void schoolComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 在学校变更时加载班级列表
            LoadClasses();
        }

        private void LoadClasses()
        {
            if (schoolComboBox.SelectedValue != null)
            {
                int schoolId = Convert.ToInt32(schoolComboBox.SelectedValue);

                // 查询班级列表
                string query = $"SELECT * FROM Class WHERE SchoolId = {schoolId}";
                DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

                // 将班级数据绑定到ListBox
                classListBox.DataSource = dataTable;
                classListBox.DisplayMember = "ClassName";
                classListBox.ValueMember = "ClassId";
            }
        }

        private void classListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 在班级变更时加载学生列表
            LoadStudents();
        }

        private void LoadStudents()
        {
            if (classListBox.SelectedValue != null)
            {
                int classId = Convert.ToInt32(classListBox.SelectedValue);

                // 查询学生列表
                string query = $"SELECT * FROM Student WHERE ClassId = {classId}";
                DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

                // 将学生数据绑定到DataGridView
                studentsDataGridView.DataSource = dataTable;
            }
        }

        private void addSchoolButton_Click(object sender, EventArgs e)
        {
            // 添加学校
            string schoolName = schoolNameTextBox.Text;
            string query = $"INSERT INTO School (SchoolName) VALUES ('{schoolName}')";
            DatabaseHelper.ExecuteNonQuery(query);

            // 刷新学校列表
            LoadSchools();

            // 记录日志
            LogAction($"Added school: {schoolName}");
        }

        private void addClassButton_Click(object sender, EventArgs e)
        {
            // 添加班级
            string className = classNameTextBox.Text;
            int schoolId = Convert.ToInt32(schoolComboBox.SelectedValue);
            string query = $"INSERT INTO Class (ClassName, SchoolId) VALUES ('{className}', {schoolId})";
            DatabaseHelper.ExecuteNonQuery(query);

            // 刷新班级列表
            LoadClasses();

            // 记录日志
            LogAction($"Added class: {className}");
        }

        private void addStudentButton_Click(object sender, EventArgs e)
        {
            // 添加学生
            string studentName = studentNameTextBox.Text;
            int classId = Convert.ToInt32(classListBox.SelectedValue);
            string query = $"INSERT INTO Student (StudentName, ClassId) VALUES ('{studentName}', {classId})";
            DatabaseHelper.ExecuteNonQuery(query);

            // 刷新学生列表
            LoadStudents();

            // 记录日志
            LogAction($"Added student: {studentName}");
        }

        private void LogAction(string logMessage)
        {
            // 记录日志
            string query = $"INSERT INTO Log (LogMessage) VALUES ('{logMessage}')";
            DatabaseHelper.ExecuteNonQuery(query);
        }
    }
}
