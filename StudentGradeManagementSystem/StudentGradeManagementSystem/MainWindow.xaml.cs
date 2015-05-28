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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentGradeManagementSystem
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private String choose;

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            choose = "student";
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            choose = "teacher";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string checkedRBName = "";
            CheckFormat cf = new CheckFormat();

            if ((teacherRadioButton.IsChecked == true) && (cf.checkTeacherIDandPassword(textbox.Text, passwordbox.Password) == 1))
            {
                checkedRBName = teacherRadioButton.Name;
                TeacherControlPage tcp = new TeacherControlPage();
                tcp.Show();
                this.Close();
            }
            //else if ((studentRadioButton.IsChecked == true)&&(cf.checkStudentIDandPassword(textbox.Text,passwordbox.Password)==1))
            else if ((studentRadioButton.IsChecked == true) && (cf.checkStudentIDandPassword(textbox.Text.ToString(), passwordbox.Password.ToString()) == 1))
            {
                checkedRBName = studentRadioButton.Name;
                StudentControlPage scp = new StudentControlPage();
                scp.Show();
                this.Close();
            }
            else if ((teacherRadioButton.IsChecked == false) && (studentRadioButton.IsChecked == false))
            {
                //display.Text = "Please choose correctly!";
                MessageBox.Show("Please choose correctly!");
            }
            else
            {
              //  display.Text = "Please input correctly!";
                MessageBox.Show("Please input correctly!");
            }

        }

    }
}
