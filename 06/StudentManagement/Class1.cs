using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    public class School
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
    }

    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int SchoolId { get; set; }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int ClassId { get; set; }
    }

    public class Log
    {
        public int LogId { get; set; }
        public string LogMessage { get; set; }
        public DateTime LogTime { get; set; }
    }

}
