using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentGradeManagementSystem
{
    /// <summary>
    /// StudentControlPage.xaml 的交互逻辑
    /// </summary>
    public partial class StudentControlPage : Window
    {
        public StudentControlPage()
        {
            InitializeComponent();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!(InputStudentID.Text == ""))
            {

                DBcontrolDataContext db = new DBcontrolDataContext();
                int num = Convert.ToInt32(InputStudentID.Text);
                var query = from s in db.Subject集
                            join c in db.Grade集 on s.subjectID equals c.Subject_subjectID
                            where c.Student_studentID == num
                            orderby s.subjectID
                            select new
                            {
                                subjectID = s.subjectID,
                                subjectName = s.subjectName,
                                score = c.score,
                                credit = s.credit,
                                SubjectType = s.subjectType
                            };
                dataGrid2.ItemsSource = query;

                dataGrid2.CanUserAddRows = false;
            }
            else
                MessageBox.Show("Please Input Your StudentID!");


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DBcontrolDataContext db = new DBcontrolDataContext();
            int num = 0;
            String name = "";

            if ((InputStudentID.Text == "") || (discription.Text == ""))
            {
                if ((InputStudentID.Text == "") && (discription.Text == ""))
                    MessageBox.Show("Please Input Your StudentID And Your Application Context!");
                else if (InputStudentID.Text == "")
                    MessageBox.Show("Please Input Your StudentID!");
                else if (discription.Text == "")
                    MessageBox.Show("Please Input Your Application Context!");

            }
            else
            {
                 num = Convert.ToInt32(InputStudentID.Text);
                var query = from s in db.Student集
                            where s.studentID == num
                            select new
                            {
                                studentname = s.studentName
                            };
               
                foreach (var item in query)
                    name = item.studentname;
                WordReport wr = new WordReport();
                wr.Report(discription.Text, InputStudentID.Text, name);
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
