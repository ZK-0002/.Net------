using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace StudentManagement
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 定义数据库文件路径
            string dbFilePath = "DatabaseFile.db";

            // 连接数据库
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dbFilePath};Version=3;"))
            {
                connection.Open();

                // 创建学校表
                using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS School (SchoolId INTEGER PRIMARY KEY AUTOINCREMENT, SchoolName TEXT);", connection))
                {
                    command.ExecuteNonQuery();
                }

                // 创建班级表
                using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Class (ClassId INTEGER PRIMARY KEY AUTOINCREMENT, ClassName TEXT, SchoolId INTEGER, FOREIGN KEY (SchoolId) REFERENCES School(SchoolId));", connection))
                {
                    command.ExecuteNonQuery();
                }

                // 创建学生表
                using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Student (StudentId INTEGER PRIMARY KEY AUTOINCREMENT, StudentName TEXT, ClassId INTEGER, FOREIGN KEY (ClassId) REFERENCES Class(ClassId));", connection))
                {
                    command.ExecuteNonQuery();
                }

                // 创建日志表
                using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Log (LogId INTEGER PRIMARY KEY AUTOINCREMENT, LogMessage TEXT, LogTime DATETIME DEFAULT CURRENT_TIMESTAMP);", connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Database and tables created successfully.");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
