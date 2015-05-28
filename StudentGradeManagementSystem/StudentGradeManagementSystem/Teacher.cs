using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradeManagementSystem
{
    class Teacher : User
    {
        private int teacherID;

        public int TeacherID
        {
            get { return teacherID; }
            set { teacherID = value; }
        }
        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        private String password;

        public String Password
        {
            get { return password; }
            set { password = value; }
        }

    }
}
