using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace StudentGradeManagementSystem
{
    class CheckFormat
    {

        public int checkStudentIDandPassword(String studentID, String studentPassword)
        {
            int i;
          //  int.TryParse(studentID, out i);
            int studentid = Convert.ToInt32(studentID);
            DBcontrolDataContext db = new DBcontrolDataContext();
            var students = db.Student集.ToList();
            foreach (var item in students)
            {
                if ((item.studentID == studentid) && (item.password == studentPassword))
                    return 1;
                else
                    return 0;

            }
            return -1;

        }

        public int checkTeacherIDandPassword(String teacherID, String teacherPassword)
        {
            if ((teacherID == "123456") && (teacherPassword == "123456"))
                return 1;
            else
                return 0;
        }
    }
}
